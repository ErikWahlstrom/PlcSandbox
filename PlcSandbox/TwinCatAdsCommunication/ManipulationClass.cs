namespace TwinCatAdsCommunication
{
    using TwinCatAdsCommunication.Address;

    public class ManipulationClass<T> : System.ComponentModel.INotifyPropertyChanged
    {
        private T valueToWrite;
        private T lastReadValue;

        public ManipulationClass(AddressBase<T> address)
        {
            this.Address = address;
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public AddressBase<T> Address { get; }

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
            internal set
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
    }
}
