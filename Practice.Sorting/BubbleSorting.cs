using System;

namespace Practice.Sorting
{
    public class BubbleSorting<T> : ISorting<T> where T : IComparable<T>
    {
        public T[] Sort(T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = i; j < elements.Length; j++)
                {
                    if (elements[i].CompareTo(elements[j]) > 0)
                    {
                        var temp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = temp;
                    }
                }
            }

            return elements;
        }
    }
}