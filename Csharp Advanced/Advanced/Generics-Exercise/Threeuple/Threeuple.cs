using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threeuple
{
    public class Threeuple<T1, T2, T3> : CustomTuple<T1, T2>
    {
        public T3 Item3 { get; set; }

        public Threeuple(T1 item1, T2 item2, T3 item3) : base(item1, item2)
        {
            Item3 = item3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }

    public class CustomTuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public CustomTuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;

        }
    }
}