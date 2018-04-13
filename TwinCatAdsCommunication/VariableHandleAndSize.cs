namespace TwinCatAdsCommunication
{
    using System.Collections.Generic;

    public class VariableHandleAndSize
    {
        public VariableHandleAndSize(int handle, int size, IEnumerable<int> arrayDims)
        {
            this.Handle = handle;
            this.Size = size;
            this.ArrayDims = arrayDims;
        }

        public int Handle { get; }

        public int Size { get; }

        public IEnumerable<int> ArrayDims { get; }
    }
}
