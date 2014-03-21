﻿using System.Collections.Generic;
using System.Linq;

namespace rm.Extensions
{
    /// <summary>
    /// IEnumerable extensions.
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// Split the collection into collections of size chunkSize.
        /// </summary>
        /// <remarks>Uses yield return/break.</remarks>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source,
            int chunkSize)
        {
            source.NullArgumentCheck("source");
            chunkSize.ArgumentRangeCheck("chunkSize");
            // to avoid inefficiency due to Count()
            var totalCount = source.Count();
            for (int start = 0; start < totalCount; start += chunkSize)
            {
                // note: skip/take is slow. not O(n) but (n/chunkSize)^2.
                // yield return source.Skip(chunk).Take(chunkSize);
                yield return source.Chunk(chunkSize, start, totalCount);
            }
        }
        /// <summary>
        /// Yield the next chunkSize elements starting at start and break if no more elements left.
        /// </summary>
        private static IEnumerable<T> Chunk<T>(this IEnumerable<T> source,
            int chunkSize, int start, int totalCount)
        {
            source.NullArgumentCheck("source");
            chunkSize.ArgumentRangeCheck("chunkSize");
            for (int i = 0; i < chunkSize; i++)
            {
                if (start + i == totalCount)
                {
                    yield break;
                }
                yield return source.ElementAt(start + i);
            }
        }
    }
}