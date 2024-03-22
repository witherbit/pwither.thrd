using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pwither.thrd.Locker
{
    public struct ReadLockToken : IDisposable
    {
        private readonly ReaderWriterLockSlim @lock;
        public ReadLockToken(ReaderWriterLockSlim @lock)
        {
            this.@lock = @lock;
            @lock.EnterReadLock();
        }
        public void Dispose() => @lock.ExitReadLock();
    }
}
