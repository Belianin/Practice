using System;

namespace Practice.Sorting
{
    public class InsertionSorting<T> : ISorting<T> where T : IComparable<T>
    {
        public T[] Sort(T[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                var elementToInsert = elements[i];
                var j = i;
                for (; j > 0; j--)
                {
                    if (elementToInsert.CompareTo(elements[j - 1]) < 0)
                        elements[j] = elements[j - 1];
                    else
                        break;
                }
                elements[j] = elementToInsert;
            }

            return elements;
        }
    }
}