using System;

namespace Practice.Sorting
{
    public interface ISorting<T> where T : IComparable<T>
    {
        T[] Sort(T[] elements);
    }
}