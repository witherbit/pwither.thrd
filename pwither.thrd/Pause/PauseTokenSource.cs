using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace pwither.thrd.Pause
{
    public class PauseTokenSource : IDisposable
    {
        private volatile TaskCompletionSource<bool> _paused;
        internal static readonly Task CompletedTask = Task.FromResult(true);
        public PauseTokenSource()
        {
            Token = new PauseToken(this);
        }
        public PauseToken Token {  get; private set; }
        public bool IsPaused => _paused != null;

        public void Pause()
        {
            Interlocked.CompareExchange(ref _paused, new TaskCompletionSource<bool>(), null);
        }

        public void Resume()
        {
            while (true)
            {
                var tcs = _paused;

                if (tcs == null)
                    return;

                if (Interlocked.CompareExchange(ref _paused, null, tcs) != tcs) continue;
                tcs.SetResult(true);
                break;
            }
        }

        public Task WaitWhilePausedAsync()
        {
            return _paused?.Task ?? CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
