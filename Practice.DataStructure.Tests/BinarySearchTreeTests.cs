using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Practice.DataStructures;
using Practice.Tests.Common;

namespace Practice.DataStructure.Tests
{
    public class BinarySearchTreeTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void Should_add_contains_and_remove_all_elements(
            IBinarySearchTree<int> tree,
            ICollection<int> elements)
        {
            foreach (var element in elements)
                tree.Add(element);

            foreach (var element in elements)
                tree.Contains(element).Should().BeTrue();

            foreach (var element in elements)
                tree.Remove(element);
            
            foreach (var element in elements)
                tree.Contains(element).Should().BeFalse();
        }

        public static IEnumerable<TestCaseData> GetTestCases()
        {
            var intArrays = TestDataProvider.GetShuffledIntArrays();
            
            foreach (var tree in GetBinarySearchTrees())
            {
                foreach (var elements in intArrays)
                {
                    yield return new TestCaseData(tree, elements)
                    {
                        TestName = $"{tree.GetType().Name} - {elements.Length} shuffled elements"
                    };
                }
            }
        }

        public static IEnumerable<IBinarySearchTree<int>> GetBinarySearchTrees()
        {
            yield return new BinarySearchTree<int>();
        }
    }
}