using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties()
                .Where(p=>p.CustomAttributes.Any(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.AttributeType)))
                .ToArray();
            foreach (PropertyInfo property in properties)
            {
                object[] customAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .ToArray();

                object propValue = property.GetValue(obj);

                foreach (object  prop in customAttributes)
                {
                    MethodInfo isValidMethod = prop.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(mi => mi.Name == "IsValid");
                    if (isValidMethod == null)
                    {
                        throw new InvalidOperationException("Your custom attribute does not have valid IsValid method!");
                    }

                    bool result = (bool)isValidMethod
                        .Invoke(prop, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
