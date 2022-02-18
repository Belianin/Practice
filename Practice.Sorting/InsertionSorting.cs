using System;

namespace Practice.Sorting
{
    public class InsertionSorting<T> : ISorting<T> where T : IComparable<T>
    {
        public T[] Sort(T[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                var temp = elements[i];
                var j = i;
                for (; j > 0; j--)
                {
                    if (temp.CompareTo(elements[j - 1]) < 0)
                    {
                        elements[j] = elements[j - 1];
                    }
                    else
                        break;
                }
                elements[j] = temp;
            }

            return elements;
        }
    }
}