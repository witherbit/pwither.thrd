#### Lock
```csharp
var locker = new Lock();
using(locker.Read())
{
    // code here
}
using(locker.Write())
{
    // code here
}
```
#### Pause
```csharp
var pauseTokenSource = new PauseTokenSource();
var token = pauseTokenSource.Token;
pauseTokenSource.Pause();
pauseTokenSource.Resume();

if (token.IsPaused)
        {
            await pauseToken.WaitWhilePausedAsync();
        }
```
