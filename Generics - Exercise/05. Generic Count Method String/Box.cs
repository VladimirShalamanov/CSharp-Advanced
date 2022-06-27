using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Box
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elementsList)
        {
            Elements = elementsList;
        }

        public T Element { get; }

        public List<T> Elements { get; }

        public void Swap(List<T> elements, int indexOne, int indexTwo)
        {
            T firstEl = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = firstEl;
        }

        public int CountOfGreater<T>(List<T> list, T readLine) where T : IComparable
            => list.Count(w => w.CompareTo(readLine) > 0);

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (T element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString().TrimEnd();
            //return $"{typeof(T)}: {Element}";
        }

        public int CompareTo(T other) => Element.CompareTo(other);

    }
}
