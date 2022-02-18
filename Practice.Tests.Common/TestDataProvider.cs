using System;
using System.Linq;

namespace Practice.Tests.Common
{
    public static class TestDataProvider
    {
        public static int[][] GetShuffledIntArrays(params int[] lengths)
        {
            var random = new Random();

            return lengths
                .Select(length =>
                    Enumerable.Range(0, length)
                        .Select(_ => random.Next(1000, 1000)).ToArray())
                .ToArray();
        }

        public static int[][] GetShuffledIntArrays() => GetShuffledIntArrays(0, 1, 10, 100, 1000);
    }
}