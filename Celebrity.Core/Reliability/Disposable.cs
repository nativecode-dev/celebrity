namespace Celebrity.Core.Reliability
{
    using System;

    public abstract class Disposable : IDisposable
    {
        protected bool Disposed { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.Disposed || disposing == false)
            {
                return;
            }

            try
            {
                this.Release();
            }
            catch
            {
                this.Disposed = true;
            }
        }

        protected abstract void Release();
    }
}