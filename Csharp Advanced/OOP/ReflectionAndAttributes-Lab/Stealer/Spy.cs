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
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance 
                                                     | BindingFlags.NonPublic 
                                                     | BindingFlags.Public 
                                                     | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo fieldName in fields.Where(f=>fieldNames.Contains(f.Name)))
            {
                
                sb.AppendLine($"{fieldName.Name} = {fieldName.GetValue(classInstance)}");
            }

            return sb.ToString();
        }
    }
}
