namespace TwinCatAdsCommunication.Address
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.IO;

    public class DoubleArrayAddress : AddressBase<ReadOnlyArray<double>>
    {
        internal DoubleArrayAddress(string name, int bitSize, int variableHandle)
            : base(name, bitSize, variableHandle)
        {
        }

        public override ReadOnlyArray<double> ReadStream(BinaryReader reader)
        {
            int valueAmount = this.BitSize / sizeof(double);
            var array = new double[valueAmount];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadDouble();
            }

            return new ReadOnlyArray<double>(array);
        }

        public override void WriteToStream(BinaryWriter writer, ReadOnlyArray<double> value)
        {
            if (value != null)
            {
                foreach (var doubleValue in value)
                {
                    writer.Write(doubleValue);
                }
            }
        }
    }

    public sealed class ReadOnlyArray<T> : IReadOnlyList<T>, INotifyCollectionChanged, INotifyPropertyChanged
        where T : struct 
    {
        private readonly T[] array;

        public ReadOnlyArray(T[] array)
        {
            this.array = array;
        }

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add => this.CollectionChanged += value;
            remove => this.CollectionChanged -= value;
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => this.PropertyChanged += value;
            remove => this.PropertyChanged -= value;
        }

        private event PropertyChangedEventHandler PropertyChanged;

        private event NotifyCollectionChangedEventHandler CollectionChanged;

        public int Count => this.array.Length;

        public T this[int index] => this.array[index];

        public IEnumerator<T> GetEnumerator() => ((IReadOnlyList<T>)this.array).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.array.GetEnumerator();

    }
}
