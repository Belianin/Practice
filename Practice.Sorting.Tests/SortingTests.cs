using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Practice.Tests.Common;

namespace Practice.Sorting.Tests
{
    public class SortingTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void Should_sort_in_ascending_order(ISorting<int> sorting, int[] elements)
        {
            var expected = elements.OrderBy(x => x).ToArray();

            var result = sorting.Sort(elements);

            result.Should().BeEquivalentTo(expected,
                opt => opt.WithStrictOrderingFor(e => e));
        }
        
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            var intArrays = TestDataProvider.GetShuffledIntArrays();

            foreach (var sorting in GetSortings())
            {
                foreach (var elements in intArrays)
                {
                    yield return new TestCaseData(sorting, elements)
                    {
                        TestName = $"{sorting.GetType().Name} - {elements.Length} shuffled elements"
                    };
                }
            }
        }

        public static IEnumerable<ISorting<int>> GetSortings()
        {
            yield return new BubbleSorting<int>();
            yield return new InsertionSorting<int>();
        }
    }
}