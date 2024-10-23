#if THEONE_UNITASK
#nullable enable
namespace TheOne.Extensions
{
    using System;
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public sealed class CancellableTask
    {
        private CancellationTokenSource? cts;

        public async UniTask RunAsync(Func<CancellationToken, UniTask> taskFactory)
        {
            this.cts ??= new();
            await taskFactory(this.cts.Token);
        }

        public void Cancel()
        {
            this.cts?.Cancel();
            this.cts?.Dispose();
            this.cts = null;
        }
    }
}
#endif