using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Practice.Sorting.Tests
{
    public class SortingTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void Should_sort_in_ascending_order(ISorting<int> sorting, int[] elements)
        {
            var expected = elements.OrderBy(x => x).ToArray();

            var result = sorting.Sort(elements);

            result.Should().BeEquivalentTo(expected);
        }
        
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            var random = new Random();
            var elements = Enumerable.Range(0, 10).Select(_ => random.Next(0, 100)).ToArray();

            foreach (var sorting in GetSortings())
            {
                yield return new TestCaseData(sorting, elements) {TestName = $"{sorting.GetType().Name}"};
            }
        }

        public static IEnumerable<ISorting<int>> GetSortings()
        {
            yield return new BubbleSorting<int>();
        }
    }
}