using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty()
        {
            if (!this.Any())
            {
                return true;
            }
            return false;
        }

        public Stack<string> AddRange()
        {
            foreach (string item in this)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
