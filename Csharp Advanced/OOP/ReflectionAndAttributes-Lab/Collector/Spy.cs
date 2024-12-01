using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Type classType =Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance
                                                              | BindingFlags.Public
                                                              | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (MethodInfo method in methods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnType}");
            }
            return sb.ToString().Trim();
        }
    }
}
