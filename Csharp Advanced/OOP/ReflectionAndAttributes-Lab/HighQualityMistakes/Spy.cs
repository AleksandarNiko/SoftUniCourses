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
        public string AnalyzeAccessModifiers(string className)  
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance 
                                                     | BindingFlags.Public  
                                                     | BindingFlags.Static);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance
                                                        | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance
                                                                 | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in publicMethods.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in nonPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }
    }
}
