namespace TwinCatAdsCommunication
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public class WriteableValue<T> : INotifyPropertyChanged, IWritableAddress
    {
        private AdsErrorCode error;
        private T valueToWrite;
        private UnconnectedAddressBase<T> unConnectedAddress;
        private AddressBase<T> address;

        public WriteableValue(UnconnectedAddressBase<T> address, ConnectedWriteClient writeClient)
        {
            this.unConnectedAddress = address;
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

        IUnconnectedAddress IAddressable.UnconnectedAddress => this.unConnectedAddress;

        public AdsErrorCode Error
        {
            get => this.error;
            set
            {
                if (value == this.error)
                {
                    return;
                }

                this.error = value;
                this.OnPropertyChanged();
            }
        }

        public T ValueToWrite
        {
            get => this.valueToWrite;
            set
            {
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
