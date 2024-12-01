using System;
using System.Collections.Generic;
namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> box;

        public Box()
        {
            box=new Stack<T>();
        }

        public void Add(T item)
        {
            box.Push(item);
        }

        public T Remove()
        {
            return box.Pop();
        }

        public int Count
        {
            get { return box.Count; }
        }
    }
}
