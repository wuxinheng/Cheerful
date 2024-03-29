﻿using System.Text;

namespace Cheerful
{
    public class Random : System.Random
    {
        public new static readonly Random Shared = new();

        /// <summary>
        /// 获取随机bool值
        /// </summary>
        /// <returns></returns>
        public virtual bool NextBoolean()
        {
            return Convert.ToBoolean(Shared.Next(0, 1));
        }

        /// <summary>
        /// 获取随机的byte
        /// </summary>
        /// <returns></returns>
        public virtual byte NextByte()
        {
            
            return Convert.ToByte(Shared.Next(byte.MinValue, byte.MaxValue));
        }

        /// <summary>
        /// 获取随机char
        /// </summary>
        /// <returns></returns>
        public virtual char NextChar()
        {
            var charValue = Shared.Next(char.MinValue, char.MaxValue);
            return Convert.ToChar(charValue);
        }

        /// <summary>
        /// 获取随机中文字符
        /// </summary>
        /// <returns></returns>
        public virtual string NextChinese()
        {
            var randomValue = Shared.Next(0x4e00, 0x9fbf);
            return Convert.ToChar(randomValue).ToString();
        }

        /// <summary>
        /// 获取随机中文字符
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns></returns>
        public virtual string NextChinese(int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var randomValue = Shared.Next(0x4e00, 0x9fbf);
                result.Append(Convert.ToChar(randomValue));
            }
            return result.ToString();
        }

        /// <summary>
        /// 获取随机decimal
        /// </summary>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public virtual decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            return Shared.Next() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// 获取随机float
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public virtual float NextFloat(float min, float max)
        {
            return Shared.Next() * (max - min) + min;
        }

        /// <summary>
        /// 获取随机float
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public virtual double NextDouble(int min, int max)
        {
            int _min = int.MinValue; int _max = int.MaxValue;
            _min = min < _min ? _min : min;
            _max = _max < max ? _max : max;

            return Shared.Next(_min, _max) + Shared.NextDouble();
        }
        /// <summary>
        /// 获取随机大写字母
        /// </summary>
        /// <returns></returns>
        public virtual string NextMajuscule()
        {
            return Convert.ToChar(Shared.Next(65, 91)).ToString();
        }

        /// <summary>
        /// 获取随机小写字母
        /// </summary>
        /// <returns></returns>
        public virtual string NextMinuscule()
        {
            return Convert.ToChar(Shared.Next(97, 123)).ToString();
        }

        /// <summary>
        /// 获取随机数字
        /// </summary>
        /// <returns></returns>
        public virtual int NextNumber()
        {
            return Shared.Next(10);
        }

        /// <summary>
        /// 获取随机数字字符串
        /// </summary>
        /// <returns></returns>
        public virtual string NextNumberString()
        {
            return Shared.Next(10).ToString();
        }
        /// <summary>
        /// 获取随机sbyte
        /// </summary>
        /// <returns></returns>
        public virtual sbyte NextSbyte()
        {
            return Convert.ToSByte(Shared.Next(sbyte.MinValue, sbyte.MaxValue));
        }

        /// <summary>
        /// 获取随机short
        /// </summary>
        /// <returns></returns>
        public virtual short NextShort()
        {
            return Convert.ToInt16(Shared.Next(short.MinValue, short.MaxValue));
        }


        public virtual short NextShort(int min, int max)
        {
            int _min = short.MinValue; int _max = short.MaxValue;
            _min = min < _min ? _min : min;
            _max = _max < max ? _max : max;
            return Convert.ToInt16(Shared.Next(_min, _max));
        }

        /// <summary>
        /// 获取随机的字符串,默认10长度
        /// </summary>
        /// <returns></returns>
        public virtual string NextString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                var random = Shared.Next(3);
                switch (random)
                {
                    case 0:
                        result.Append(Shared.NextNumber());//小写
                        break;

                    case 1:
                        result.Append(Shared.NextMajuscule()); //大写
                        break;

                    case 2:
                        result.Append(Shared.NextMinuscule());//小写
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected value random = {random}");
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        public virtual string NextString(int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var random = Shared.Next(3);
                switch (random)
                {
                    case 0:
                        result.Append(Shared.NextNumber());//小写
                        break;

                    case 1:
                        result.Append(Shared.NextMajuscule()); //大写
                        break;

                    case 2:
                        result.Append(Shared.NextMinuscule());//小写
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected value random = {random}");
                }
            }

            return result.ToString();
        }
        /// <summary>
        /// 获取随机uint
        /// </summary>
        /// <returns></returns>
        public virtual uint NextUInt()
        {
            return Convert.ToUInt32(Shared.NextByte());
        }

        /// <summary>
        /// 获取随机uint
        /// </summary>
        /// <returns></returns>
        public virtual uint NextUInt(int min, int max)
        {
            int _min = int.MinValue; int _max = int.MaxValue;
            _min = min < _min ? _min : min;
            _max = _max < max ? _max : max;
            return Convert.ToUInt32(Shared.Next(_min, _max));
        }

        /// <summary>
        /// 获取随机ulong
        /// </summary>
        /// <returns></returns>
        public virtual ulong NextULong()
        {
            return Convert.ToUInt64(Shared.NextByte());
        }

        /// <summary>
        /// 获取随机ulong
        /// </summary>
        /// <returns></returns>
        public virtual ulong NextULong(int min, int max)
        {
            int _min = int.MinValue; int _max = int.MaxValue;
            _min = min < _min ? _min : min;
            _max = _max < max ? _max : max;
            return Convert.ToUInt64(Shared.Next(_min, _max));
        }

        /// <summary>
        /// 获取随机ushort
        /// </summary>
        /// <returns></returns>
        public virtual ushort NextUShort()
        {
            return Convert.ToUInt16(Shared.NextByte());
        }

        /// <summary>
        /// 获取随机ushort
        /// </summary>
        /// <returns></returns>
        public virtual ushort NextUShort(int min, int max)
        {
            int _min = ushort.MinValue; int _max = ushort.MaxValue;
            _min = min < _min ? _min : min;
            _max = _max < max ? _max : max;
            return Convert.ToUInt16(Shared.Next(_min, _max));
        }
    }
}