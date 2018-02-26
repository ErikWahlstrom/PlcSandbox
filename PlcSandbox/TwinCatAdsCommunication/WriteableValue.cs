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
        private readonly AddressBase<T> internalAddress;
        private AdsErrorCode error;
        private T valueToWrite;

        public WriteableValue(AddressBase<T> address)
        {
            this.internalAddress = address;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private event EventHandler WrittenToPlc;

        public IAddress Address => this.internalAddress;

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
            this.internalAddress.WriteToStream(writer, this.ValueToWrite);
        }

        public void NotifyWritten()
        {
            this.OnWrittenToPlc();
        }

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnWrittenToPlc()
        {
            this.WrittenToPlc?.Invoke(this, EventArgs.Empty);
        }
    }
}
