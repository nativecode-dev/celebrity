namespace Celebrity.Core.Reliability
{
    using System;
    using System.Collections.Concurrent;

    public class DisposableManager : Disposable
    {
        private readonly ConcurrentBag<IDisposable> disposables;

        public DisposableManager()
        {
            this.disposables = new ConcurrentBag<IDisposable>();
        }

        protected void DeferDispose(IDisposable disposasble)
        {
            this.disposables.Add(disposasble);
        }

        protected override void Release()
        {
            while (this.disposables.TryTake(out var disposable))
            {
                disposable.Dispose();
            }
        }
    }
}