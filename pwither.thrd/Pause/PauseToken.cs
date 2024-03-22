using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pwither.thrd.Pause
{
    public readonly struct PauseToken
    {
        private readonly PauseTokenSource _tokenSource;
        public bool IsPaused => _tokenSource?.IsPaused == true;

        public PauseToken(PauseTokenSource source)
        {
            _tokenSource = source;
        }

        public Task WaitWhilePausedAsync()
        {
            return IsPaused
                ? _tokenSource.WaitWhilePausedAsync()
                : PauseTokenSource.CompletedTask;
        }
    }
}
