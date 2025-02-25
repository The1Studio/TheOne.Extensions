﻿#nullable enable
namespace UniT.Extensions
{
    using System.Collections.Generic;

    public static class Ranges
    {
        public static From From(int start) => new From(start);

        public static IEnumerable<int> To(int stop) => new From(0).To(stop);

        public static IEnumerable<int> Take(int count) => new From(0).Take(count);
    }

    public readonly struct From
    {
        private readonly int start;

        public From(int start)
        {
            this.start = start;
        }

        public IEnumerable<int> To(int stop)
        {
            var start = this.start;
            while (start < stop) yield return start++;
        }

        public IEnumerable<int> Take(int count)
        {
            return this.To(this.start + count);
        }
    }
}