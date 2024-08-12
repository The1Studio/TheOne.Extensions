#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ParallelEnumerableExtensions
    {
        public static void ParallelForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Parallel.ForEach(enumerable, action);
        }

        public static int FirstIndex<T>(this ParallelQuery<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable.Enumerate().First((_, item) => predicate(item)).Item1;
        }

        public static int LastIndex<T>(this ParallelQuery<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable.Enumerate().Last((_, item) => predicate(item)).Item1;
        }

        public static ParallelQuery<T> Shuffle<T>(this ParallelQuery<T> enumerable)
        {
            return enumerable.OrderBy(_ => Guid.NewGuid());
        }

        public static ParallelQuery<T> Sample<T>(this ParallelQuery<T> enumerable, int count)
        {
            return enumerable.Shuffle().Take(count);
        }

        public static ParallelQuery<(int Index, T Value)> Enumerate<T>(this ParallelQuery<T> enumerable, int start = 0)
        {
            return enumerable.Select(item => (start++, item));
        }
    }
}