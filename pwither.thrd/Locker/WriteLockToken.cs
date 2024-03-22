using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pwither.thrd.Locker
{
    public struct WriteLockToken : IDisposable
    {
        private readonly ReaderWriterLockSlim @lock;
        public WriteLockToken(ReaderWriterLockSlim @lock)
        {
            this.@lock = @lock;
            @lock.EnterWriteLock();
        }
        public void Dispose() => @lock.ExitWriteLock();
    }
}
