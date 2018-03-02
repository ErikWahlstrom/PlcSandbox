namespace TwinCatAdsCommunication
{
    public class VariableHandleAndSize
    {
        public VariableHandleAndSize(int handle, int size)
        {
            this.Handle = handle;
            this.Size = size;
        }

        public int Handle { get; }

        public int Size { get; }
    }
}