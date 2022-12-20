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
        /// 随机初始化枚举
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns>返回动态类型,默认返回null</returns>
        /// <exception cref="ArgumentException">类型不匹配</exception>
        public static dynamic? InitEnum(Type? @type)
        {
            dynamic? reuslt=null;
            if (type!.IsEnum)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
                reuslt = Enum.Parse(type, fields[Random.Shared.Next(fields.Length)].Name);
            }
            return reuslt;
        }

        /// <summary>
        /// 随机初始化系统基础类型，不支持 delegate、object、dynamic、class、interface、delegate、record
        /// </summary>
        /// <param name="type">需要初始化的类型</param>
        /// <returns>返回动态类型,默认返回null</returns>
        public static dynamic? InitSystemBaseType(Type? @type)
        {
            dynamic? result;

            result = InitEnum(type);
            if (result != null)
            {
                return result;
            }

            switch (Type.GetTypeCode(@type))
            {
                case TypeCode.Empty:
                    break;

                case TypeCode.Object:
                    if (@type!.IsGenericType && @type?.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        var underlyingType = Nullable.GetUnderlyingType(@type);
                        result = InitSystemBaseType(underlyingType);
                    }
                    else
                    {
                        //delegate、object、dynamic、class、interface、delegate、record
                    }
                    break;

                case TypeCode.DBNull:
                    break;

                case TypeCode.Boolean:
                    result = Random.Shared.NextBoolean();
                    break;

                case TypeCode.Char:
                    result = Random.Shared.NextChar();
                    break;

                case TypeCode.SByte:
                    result = Random.Shared.NextSbyte();
                    break;

                case TypeCode.Byte:
                    result = Random.Shared.NextByte();
                    break;

                case TypeCode.Int16:
                    result = Random.Shared.NextShort();
                    break;

                case TypeCode.UInt16:
                    result = Random.Shared.NextUShort();
                    break;

                case TypeCode.Int32:
                    result = Random.Shared.Next();
                    break;

                case TypeCode.UInt32:
                    result = Random.Shared.NextUInt();
                    break;

                case TypeCode.Int64:
                    result = Random.Shared.Next();
                    break;

                case TypeCode.UInt64:
                    result = Random.Shared.NextULong();
                    break;

                case TypeCode.Single:
                    result = Random.Shared.NextFloat(1, 100);
                    break;

                case TypeCode.Double:
                    result = Random.Shared.NextDouble();
                    break;

                case TypeCode.Decimal:
                    result = Random.Shared.NextDecimal(1, 100);
                    break;

                case TypeCode.DateTime:
                    result = DateTime.Now;
                    break;

                case TypeCode.String:
                    result = Random.Shared.NextString();
                    break;

                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 根据对象属性信息随机设置值
        /// </summary>
        /// <param name="object">对象</param>
        /// <param name="propertyInfos">属性集合</param>
        private static void SetPropertyInfo(object @object, PropertyInfo[] propertyInfos)
        {
            foreach (var item in propertyInfos)
            {
                var value = InitSystemBaseType(item.PropertyType);
                item.SetValue(@object, value);
            }
        }
    }
}