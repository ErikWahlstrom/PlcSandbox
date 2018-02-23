namespace TwinCatAdsCommunication
{
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public class BindableValue<T> : System.ComponentModel.INotifyPropertyChanged, IReadableAddress, IWritableAddress
    {
        private readonly AddressBase<T> internalAddress;
        private bool isInitialized;
        private AdsErrorCode error;
        private T valueToWrite;
        private T lastReadValue;
        private T writtenValue;
        private T lastWrittenToStream;

        public BindableValue(AddressBase<T> address)
        {
            this.internalAddress = address;
            this.IsInitialized = false;
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public IAddress Address => this.internalAddress;

        public bool IsInitialized
        {
            get => this.isInitialized;
            private set
            {
                if (value == this.isInitialized)
                {
                    return;
                }

                this.isInitialized = value;
                this.OnPropertyChanged();
            }
        }

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

        public T LastReadValue
        {
            get => this.lastReadValue;
            private set
            {
                if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(value, this.lastReadValue))
                {
                    return;
                }

                this.lastReadValue = value;
                this.OnPropertyChanged();
            }
        }

        public T WrittenValue
        {
            get => this.writtenValue;
            private set
            {
                if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(value, this.writtenValue))
                {
                    return;
                }

                this.writtenValue = value;
                this.OnPropertyChanged();
            }
        }

        public void UpdateValue(BinaryReader stream)
        {
            this.IsInitialized = true;
            this.LastReadValue = this.internalAddress.ReadStream(stream);
        }

        public Task WriteAsync(T value)
        {
            this.ValueToWrite = value;
            var tcs = new TaskCompletionSource<object>();
            this.PropertyChanged += OnPropertyChanged;
            return tcs.Task;

            void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(this.WrittenValue))
                {
                    this.PropertyChanged -= OnPropertyChanged;
                    tcs.SetResult(null);
                }
            }
        }

        public void WriteValueToStream(BinaryWriter writer)
        {
            this.internalAddress.WriteToStream(writer, this.ValueToWrite);
            this.WrittenValue = default(T); // Inte alls så snyggt. Hur hantera? Kanske event istället?
            this.lastWrittenToStream = this.valueToWrite;
        }

        public void UpdateWritten()
        {
            this.WrittenValue = this.lastWrittenToStream;
        }

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
