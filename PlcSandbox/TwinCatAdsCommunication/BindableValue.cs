namespace TwinCatAdsCommunication
{
    using System.IO;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public class BindableValue<T> : System.ComponentModel.INotifyPropertyChanged, IReadableAddress, IWritableAddress
    {
        private bool isInitialized;
        private T valueToWrite;
        private T lastReadValue;
        private AddressBase<T> internalAddress;

        public BindableValue(AddressBase<T> address)
        {
            this.internalAddress = address;
            this.IsInitialized = false;
        }

        public IAddress Address => this.internalAddress;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

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

        public object ValueToWrite => this.TypedValueToWrite;

        public T TypedValueToWrite
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

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        public void UpdateValue(AdsStream stream)
        {
            this.IsInitialized = true;
            LastReadValue = Address.ReadStream(stream);
            throw new System.NotImplementedException();
        }

        public void WriteValueToStream(BinaryWriter writer)
        {
            throw new System.NotImplementedException();
        }
    }
}
