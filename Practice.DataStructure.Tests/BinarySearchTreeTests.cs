using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Practice.DataStructures;

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
            var random = new Random();
            var elements = Enumerable.Range(0, 10).Select(_ => random.Next(0, 100)).ToArray();

            foreach (var tree in GetBinarySearchTrees())
            {
                yield return new TestCaseData(tree, elements) {TestName = $"{tree.GetType().Name}"};
            }
        }

        public static IEnumerable<IBinarySearchTree<int>> GetBinarySearchTrees()
        {
            yield return new BinarySearchTree<int>();
        }
    }
}