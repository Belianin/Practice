using System;

namespace Practice.DataStructures
{
    public interface IBinarySearchTree<in T> where T : IComparable<T>
    {
        bool Contains(T element);
        void Add(T element);
        void Remove(T element);
        int Count { get; }
    }
}
