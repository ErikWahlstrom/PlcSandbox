namespace TwinCatAdsCommunication
{
    using System.IO;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public class BindableValue<T> : System.ComponentModel.INotifyPropertyChanged, IReadableAddress, IWritableAddress
    {
        private readonly AddressBase<T> internalAddress;
        private bool isInitialized;
        private T valueToWrite;
        private T lastReadValue;

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

        public void UpdateValue(BinaryReader stream)
        {
            this.IsInitialized = true;
            this.LastReadValue = this.internalAddress.ReadStream(stream);
        }

        public void WriteValueToStream(BinaryWriter writer)
        {
            this.internalAddress.WriteToStream(writer, this.ValueToWrite);
        }

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
