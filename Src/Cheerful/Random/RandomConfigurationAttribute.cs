namespace Cheerful
{
    /// <summary>
    /// 随机设置
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RandomConfigurationAttribute : Attribute
    {
        /// <summary>
        /// 指定生成类型
        /// </summary>
        private BuildType BuildType { get; set; }

        /// <summary>
        /// 数值类型生成范围
        /// </summary>
        private (int Min, int Max) Range { get; set; }

        /// <summary>
        /// 字符类型长度
        /// </summary>
        private int Length { get; set; }

        /// <summary>
        /// 随机类型
        /// </summary>
        private RandomType RandomType { get; set; }


        public RandomConfigurationAttribute(BuildType buildType)
        {
            RandomType = RandomType.Type;
            BuildType = buildType;
        }

        public RandomConfigurationAttribute(int min, int max)
        {
            Range = (min, max);
            RandomType = RandomType.Range;
        }

        public RandomConfigurationAttribute(int length)
        {
            Length = length;
            RandomType = RandomType.Length;
        }

        public dynamic? ToRandom(Type? type)
        {
            var typeCode = Type.GetTypeCode(@type);

            switch (RandomType)
            {
                case RandomType.Range:
                    switch (typeCode)
                    {
                        case TypeCode.Int16:
                            return Random.Shared.NextShort(Range.Min,Range.Max);
                        case TypeCode.UInt16:
                            return Random.Shared.NextUShort(Range.Min, Range.Max);
                        case TypeCode.Int32:
                            return Random.Shared.Next(Range.Min, Range.Max);
                        case TypeCode.UInt32:
                            return Random.Shared.NextUInt(Range.Min, Range.Max);
                        case TypeCode.Int64:
                            return Random.Shared.Next(Range.Min, Range.Max);
                        case TypeCode.UInt64:
                            return Random.Shared.NextULong(Range.Min, Range.Max);
                        case TypeCode.Single:
                            return Random.Shared.NextFloat(Range.Min, Range.Max);
                        case TypeCode.Double:
                            return Random.Shared.NextDouble(Range.Min, Range.Max);
                        case TypeCode.Decimal:
                            return Random.Shared.NextDecimal(Range.Min, Range.Max);
                        case TypeCode.Empty:
                        case TypeCode.Object:
                        case TypeCode.DBNull:
                        case TypeCode.Boolean:
                        case TypeCode.Char:
                        case TypeCode.SByte:
                        case TypeCode.Byte:
                        case TypeCode.DateTime:
                        case TypeCode.String:
                        default:
                            break;
                    }
                    break;
                case RandomType.Length:
                    switch (typeCode)
                    {
                        case TypeCode.String:
                            return Random.Shared.NextString(Length);
                        case TypeCode.Empty:
                        case TypeCode.Object:
                        case TypeCode.DBNull:
                        case TypeCode.Boolean:
                        case TypeCode.Char:
                        case TypeCode.SByte:
                        case TypeCode.Byte:
                        case TypeCode.Int16:
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                        case TypeCode.DateTime:
                        default:
                            break;
                    }
                    break;
                case RandomType.Type:
                    switch (typeCode)
                    {
                        case TypeCode.String:
                            switch (BuildType)
                            {
                                case BuildType.Name:
                                    return Random.Shared.NextChinese(Random.Shared.Next(2,3));
                                case BuildType.EMail:
                                    return $"{Random.Shared.NextString(Random.Shared.Next(6, 8))}@{Random.Shared.NextString(Random.Shared.Next(3))}.com";
                                default:
                                    break;
                            }
                            break;
                        case TypeCode.Empty:
                        case TypeCode.Object:
                        case TypeCode.DBNull:
                        case TypeCode.Boolean:
                        case TypeCode.Char:
                        case TypeCode.SByte:
                        case TypeCode.Byte:
                        case TypeCode.Int16:
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                        case TypeCode.DateTime:
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return null;
        }
    }

    /// <summary>
    /// 随机类型
    /// </summary>
    internal enum RandomType
    {
        Range,
        Length,
        Type
    }

    /// <summary>
    /// 生成类型
    /// </summary>
    public enum BuildType
    {
        Name,
        EMail,
    }
}
