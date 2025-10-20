#if THEONE_UNITASK
#nullable enable
namespace TheOne.Extensions
{
    using System;
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;

    public static class TupleUniTaskExtensions
    {
        public static async UniTask ForEachAwaitAsync<TFirst, TSecond>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask> action)
        {
            foreach (var tuple in tuples) await action(tuple.Item1, tuple.Item2);
        }

        public static async UniTask ForEachAwaitAsync<TFirst, TSecond, TThird>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask> action)
        {
            foreach (var tuple in tuples) await action(tuple.Item1, tuple.Item2, tuple.Item3);
        }

        public static async UniTask ForEachAsync<TFirst, TSecond>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask> action)
        {
            await tuples.Select(action);
        }

        public static async UniTask ForEachAsync<TFirst, TSecond, TThird>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask> action)
        {
            await tuples.Select(action);
        }

        public static async UniTask<IEnumerable<TResult>> SelectAsync<TFirst, TSecond, TResult>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask<TResult>> selector)
        {
            return await tuples.Select(selector);
        }

        public static async UniTask<IEnumerable<TResult>> SelectAsync<TFirst, TSecond, TThird, TResult>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask<TResult>> selector)
        {
            return await tuples.Select(selector);
        }

        public static UniTask ContinueWith<TFirst, TSecond>(this UniTask<(TFirst, TSecond)> task, Func<TFirst, TSecond, UniTask> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2));
        }

        public static UniTask ContinueWith<TFirst, TSecond, TThird>(this UniTask<(TFirst, TSecond, TThird)> task, Func<TFirst, TSecond, TThird, UniTask> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3));
        }

        public static UniTask ContinueWith<TFirst, TSecond>(this UniTask<(TFirst, TSecond)> task, Action<TFirst, TSecond> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2));
        }

        public static UniTask ContinueWith<TFirst, TSecond, TThird>(this UniTask<(TFirst, TSecond, TThird)> task, Action<TFirst, TSecond, TThird> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3));
        }

        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TResult>(this UniTask<(TFirst, TSecond)> task, Func<TFirst, TSecond, UniTask<TResult>> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2));
        }

        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TThird, TResult>(this UniTask<(TFirst, TSecond, TThird)> task, Func<TFirst, TSecond, TThird, UniTask<TResult>> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3));
        }

        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TResult>(this UniTask<(TFirst, TSecond)> task, Func<TFirst, TSecond, TResult> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2));
        }

        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TThird, TResult>(this UniTask<(TFirst, TSecond, TThird)> task, Func<TFirst, TSecond, TThird, TResult> continuationFunction)
        {
            return task.ContinueWith(tuple => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3));
        }
    }
}
#endif