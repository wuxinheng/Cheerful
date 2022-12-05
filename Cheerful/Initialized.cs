using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful
{
    public static class Initialized
    {

        public static T Init<T>()
            where T : class, new()
        {
            Random random = new Random();
            var type = typeof(T);
            var @object = System.Activator.CreateInstance<T>();
            dynamic randomValue = random.Next(0, 1);
            foreach (var item in type.GetProperties())
            {
                if (item.PropertyType.IsSubclassOf(typeof(Delegate)))
                {
                    item.SetValue(@object, default);
                }
                else if (item.PropertyType.IsArray)
                {
                    item.SetValue(@object, default);
                }
                else if (item.PropertyType == typeof(bool))
                {
                    randomValue = random.Next(0, 1);
                    item.SetValue(@object, Convert.ToBoolean(randomValue));
                }
                else if (item.PropertyType == typeof(byte))
                {
                    randomValue = random.Next(0, 255);
                    item.SetValue(@object, (byte)randomValue);
                }
                else if (item.PropertyType == typeof(char))
                {
                    item.SetValue(@object, (byte)randomValue);
                }
                else
                {
                    item.SetValue(@object, null);
                }
            }
            return new T();
        }

        public static IEnumerable<T> InitCollection<T>()
        {
            return new List<T>();
        }
    }
}
