namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;
    using TwinCatAdsCommunication.Address;

    public class WriteableValue<T> : INotifyPropertyChanged, IWritableAddress
    {
        private readonly UnconnectedAddressBase<T> unConnectedAddress;
        private readonly ConnectedWriteClient writeClient;
        private T valueToWrite;
        private Exception exception;
        private AddressBase<T> address;

        public WriteableValue(UnconnectedAddressBase<T> address, ConnectedWriteClient writeClient)
        {
            this.unConnectedAddress = address;
            this.writeClient = writeClient;
            writeClient.RegisterCyclicWriting(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private event EventHandler WrittenToPlc;

        IAddress IAddressable.Address
        {
            get => this.address;
            set
            {
                this.address = (AddressBase<T>)value;
                using (var stream = PlcReader.ReadValue(this.writeClient.Client, this))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        reader.CheckErrors(new List<IAddressable>() { this });
                        this.ValueToWrite = this.Address.ReadStream(reader);
                    }
                }

                this.OnPropertyChanged(nameof(this.Address));
            }
        }

        public AddressBase<T> Address
        {
            get => this.address;
            set
            {
                if (ReferenceEquals(value, this.address))
                {
                    return;
                }

                this.address = value;
                this.OnPropertyChanged();
            }
        }

        public Exception Exception
        {
            get => this.exception;
            set
            {
                if (ReferenceEquals(value, this.exception))
                {
                    return;
                }

                this.exception = value;
                this.OnPropertyChanged();
            }
        }

        IUnconnectedAddress IAddressable.UnconnectedAddress => this.unConnectedAddress;

        public T ValueToWrite
        {
            get => this.valueToWrite;
            set
            {
                if (this.address == null)
                {
                    throw new InvalidOperationException("The value has not yet been updated from the Plc");
                }

                if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(value, this.valueToWrite))
                {
                    return;
                }

                this.valueToWrite = value;
                this.OnPropertyChanged();
            }
        }

        public Task WriteAsync(T value)
        {
            this.ValueToWrite = value;
            var tcs = new TaskCompletionSource<object>();
            this.WrittenToPlc += OnWritten;
            return tcs.Task;

            void OnWritten(object sender, EventArgs e)
            {
                this.WrittenToPlc -= OnWritten;
                tcs.SetResult(null);
            }
        }

        public void WriteValueToStream(BinaryWriter writer)
        {
            this.address.WriteToStream(writer, this.ValueToWrite);
        }

        public void NotifyWritten()
        {
            this.OnWrittenToPlc();
        }

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnWrittenToPlc()
        {
            this.WrittenToPlc?.Invoke(this, EventArgs.Empty);
        }
    }
}
