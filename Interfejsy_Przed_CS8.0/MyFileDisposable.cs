namespace Interfejsy_CS
{
    internal class MyFileDisposable : IDisposable
    {
        void IDisposable.Dispose()
        {
            Close();
        }

        public void Close()
        {
            // Do what's necessary to close the file
            GC.SuppressFinalize(this);
        }
    }
}