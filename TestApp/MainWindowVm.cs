namespace TestApp
{
    using System.ComponentModel;
    using System.Windows;

    public sealed class MainWindowVm : System.IDisposable
    {
        private bool disposed;

        public MainWindowVm()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

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
