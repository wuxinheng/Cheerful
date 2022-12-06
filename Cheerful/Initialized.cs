using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful
{
    public static class Initialized
    {

        public static T Init<T>() where T : class, new()
        {

            var type = typeof(T);
            var @object = System.Activator.CreateInstance<T>();
            var propertyInfos = type.GetProperties();

            foreach (var item in propertyInfos)
            {
                if (item.PropertyType.IsSubclassOf(typeof(Delegate)))
                {
                    item.SetValue(@object, default);  // 暂不处理
                }
                else if (item.PropertyType.IsArray)
                {
                    item.SetValue(@object, default);  // 暂不处理
                }
                else if (item.PropertyType == typeof(bool))
                    item.SetValue(@object, Random.Shared.NextBoolean());
                else if (item.PropertyType == typeof(byte))
                    item.SetValue(@object, Random.Shared.NextByte());
                else if (item.PropertyType == typeof(char))
                    item.SetValue(@object, Random.Shared.NextChar());
                else if (item.PropertyType == typeof(decimal))
                    item.SetValue(@object, Random.Shared.NextDecimal(1, 100));
                else if (item.PropertyType == typeof(float))
                    item.SetValue(@object, Random.Shared.NextFloat(1, 100));
                else if (item.PropertyType == typeof(string))
                    item.SetValue(@object, Random.Shared.NextString());
                else if (item.PropertyType == typeof(double))
                    item.SetValue(@object, Random.Shared.NextDouble());
                else if (item.PropertyType == typeof(int))
                    item.SetValue(@object, Random.Shared.Next());
                else if (item.PropertyType == typeof(long))
                    item.SetValue(@object, Random.Shared.Next());
                else if (item.PropertyType == typeof(nint))
                    item.SetValue(@object, default);
                else if (item.PropertyType == typeof(nuint))
                    item.SetValue(@object, default);
                else if (item.PropertyType == typeof(sbyte))
                    item.SetValue(@object, Random.Shared.NextSbyte());
                else if (item.PropertyType == typeof(short))
                    item.SetValue(@object, Random.Shared.NextShort());
                else if (item.PropertyType == typeof(uint))
                    item.SetValue(@object, default);
                else if (item.PropertyType == typeof(ulong))
                    item.SetValue(@object, default);
                else if (item.PropertyType == typeof(ushort))
                    item.SetValue(@object, default);
                else if (!item.PropertyType.IsValueType)
                {
                    item.SetValue(@object, default);
                }
                else
                {
                    item.SetValue(@object, null);
                }
            }
            return @object;
        }

        public static IEnumerable<T> InitCollection<T>()
        {
            return new List<T>();
        }


    }
}
