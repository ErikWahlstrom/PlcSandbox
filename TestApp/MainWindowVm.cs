namespace TestApp
{
    public sealed class MainWindowVm : System.IDisposable
    {
        private bool disposed;

        public MainWindowVm()
        {
            this.ReadValues = new ConnectedReadValues();
            this.WriteValues = new ConnectedWriteValues();
        }

        public ConnectedWriteValues WriteValues { get; }

        public ConnectedReadValues ReadValues { get; }

        public void Dispose()
        {
            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
            this.ReadValues.Dispose();
            this.WriteValues.Dispose();
        }
    }
}
