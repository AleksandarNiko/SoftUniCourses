using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
            private List<T> elements;

            public Stack(params T[] items)
            {
                elements = new List<T>(items);
            }

            public void Push(params T[] elements)
            {
                foreach (var item in elements)
                {
                    this.elements.Insert(this.elements.Count, item);
                }
            }

            public T Pop()
            {
                if (elements.Count == 0)
                {
                    throw new ArgumentException("No elements");
                }

                T element = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                return element;
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = elements.Count - 1; i >= 0; i--)
                {
                    yield return elements[i];
                }

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    }
    }

