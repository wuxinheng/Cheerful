//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////namespace Cheerful.Random
////{
////    /// <summary>
////    /// 支持中英文、数字范围、字母大小写、长度、自定义字符、常用类型
////    /// <list type="1">
////    /// <item >姓名：中文、双字、三字、四字、少数名族</item>
////    /// <item>邮箱</item>
////    /// <item>手机号</item>
////    /// <item>地址：省份市区限定、国内地址</item>
////    /// <item>经纬度：待定</item>
////    /// <item>身份证号</item>
////    /// <item>公司名称：国内公司</item>
////    /// <item>密码：密码难度</item>
////    /// <item>昵称：{形容词:名称}</item>
////    /// <item>机动车牌号：新能源、燃油车</item>
////    /// </list>
////    /// </summary>
////    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
////    public class RandomFormatAttribute : Attribute
////    {
////        /// <summary>
////        /// 格式:
////        /// C:中文
////        /// E:大写英文字母
////        /// e:小写英文字母
////        /// d:digit 0-9
////        /// ^d:
////        /// ~
////        /// `
////        /// ^
////        /// _
////        /// '
////        /// "
////        /// ~
////        /// </summary>
////        private readonly string? _format;
////        private readonly BuildType _buildType;


////        public RandomFormatAttribute(string format)
////        {
////            _format = format;
////        }

////        public RandomFormatAttribute(BuildType buildType)
////        {
////            _buildType = buildType;
////        }


////        public enum BuildType
////        {
////            NAME = 1,
////            MAIL = 3,
////            TEL = 5,
////            ADDRESS = 7,
////            ID = 9,
////            PASSWORD = 11,
////            NETWORK_NAME = 13,
////            LICENSE_PLATE = 15,
////        }
////    }
////}
