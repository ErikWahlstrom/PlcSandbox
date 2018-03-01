namespace TwinCatAdsCommunication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TwinCAT.Ads;
    using TwinCatAdsCommunication.Address;

    public class ReadableValue<T> : INotifyPropertyChanged, IReadableAddress
    {
        private readonly ConnectedReadClient connectedReadClient;
        private AddressBase<T> address;
        private AdsErrorCode error;
        private T lastReadValue;

        public ReadableValue(UnconnectedAddressBase<T> address, ConnectedReadClient connectedReadClient)
        {
            this.connectedReadClient = connectedReadClient;
            this.InitialAddress = address;
            connectedReadClient.RegisterForCyclicReading(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private event EventHandler ReadFromPlc;

        public UnconnectedAddressBase<T> InitialAddress { get; }

        IAddress IAddressable.Address
        {
            get => this.address;
            set
            {
                this.address = (AddressBase<T>) value;
                this.OnPropertyChanged(nameof(this.Address));
            }
        }

        IUnconnectedAddress IAddressable.UnconnectedAddress => this.InitialAddress;

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
            this.LastReadValue = this.Address.ReadStream(stream);
            this.OnReadFromPlc();
        }

        public IAddress GetConnectedAddress()
        {
            return this.InitialAddress.GetConnectedAddress(this.connectedReadClient);
        }

        public Task ReadAsync()
        {
            var tcs = new TaskCompletionSource<object>();
            this.ReadFromPlc += OnReadFromPlc;
            return tcs.Task;

            void OnReadFromPlc(object sender, EventArgs e)
            {
                this.ReadFromPlc -= OnReadFromPlc;
                tcs.SetResult(null);
            }
        }

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnReadFromPlc()
        {
            this.ReadFromPlc?.Invoke(this, EventArgs.Empty);
        }
    }
}
