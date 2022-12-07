using System.Reflection;

namespace Cheerful
{
    public static class Initialized
    {
        /// <summary>
        /// 随机初始化一个对象
        /// </summary>
        /// <typeparam name="T">任意对象类型</typeparam>
        /// <returns></returns>
        public static T Init<T>() where T : class
        {
            var type = typeof(T);
            var @object = System.Activator.CreateInstance<T>();
            var propertyInfos = type.GetProperties();
            SetPropertyInfo(@object, propertyInfos);
            return @object;
        }

        /// <summary>
        /// 随机初始化一个对象集合
        /// </summary>
        /// <typeparam name="T">任意对象类型</typeparam>
        /// <param name="length">集合长度</param>
        /// <returns></returns>
        public static IEnumerable<T> InitCollection<T>(int length) where T : class
        {
            var type = typeof(T);
            var objects = new List<T>();
            var propertyInfos = type.GetProperties();

            for (int i = 0; i < length; i++)
            {
                var @object = System.Activator.CreateInstance<T>();
                SetPropertyInfo(@object, propertyInfos);
                objects.Add(@object);
            }
            return @objects;
        }

        /// <summary>
        /// 根据对象属性信息随机设置值
        /// </summary>
        /// <param name="object"></param>
        /// <param name="propertyInfos"></param>
        private static void SetPropertyInfo(object @object, PropertyInfo[] propertyInfos)
        {
            foreach (var item in propertyInfos)
            {
                if (item.PropertyType == typeof(bool))
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
                else if (item.PropertyType == typeof(sbyte))
                    item.SetValue(@object, Random.Shared.NextSbyte());
                else if (item.PropertyType == typeof(short))
                    item.SetValue(@object, Random.Shared.NextShort());
                else if (item.PropertyType == typeof(uint))
                    item.SetValue(@object, Random.Shared.NextUInt());
                else if (item.PropertyType == typeof(ulong))
                    item.SetValue(@object, Random.Shared.NextULong());
                else if (item.PropertyType == typeof(ushort))
                    item.SetValue(@object, Random.Shared.NextUShort());
                else
                {
                    // typeof(nint) typeof(nuint) IsArray IsSubclassOf(typeof(Delegate))
                    item.SetValue(@object, default);
                }
            }
        }
    }
}