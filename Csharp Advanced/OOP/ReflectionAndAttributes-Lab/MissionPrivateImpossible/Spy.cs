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
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance
                                                                 | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {this.GetType().BaseType.Name}");

            foreach (MethodInfo method in nonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }
    }
}
