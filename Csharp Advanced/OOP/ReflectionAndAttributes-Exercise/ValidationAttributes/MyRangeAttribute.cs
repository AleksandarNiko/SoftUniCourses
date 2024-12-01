using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRangeAttribute:MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            return (int)obj >= this.minValue && (int)obj <= this.maxValue;
        }
    }
}
