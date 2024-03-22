using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pwither.thrd.Locker
{
    public class Lock : IDisposable
    {
        private readonly ReaderWriterLockSlim @lock = new ReaderWriterLockSlim();

        public ReadLockToken Read() => new ReadLockToken(@lock);
        public WriteLockToken Write() => new WriteLockToken(@lock);

        public void Dispose() => @lock.Dispose();
    }
}
