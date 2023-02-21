using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful.Repository
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ObjectCodeAttribute : Attribute
    {
        public ObjectCodeAttribute() { }
        public ObjectCodeAttribute(string postfix = "", int sequenceLength = 0, string prefix = "")
        {
            Postfix = postfix;
            Prefix = prefix;
            SequenceLength = sequenceLength;
        }

        /// <summary>
        /// 前缀
        /// </summary>
        public string? Prefix { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string? Postfix { get; set; }

        /// <summary>
        /// 序号长度
        /// </summary>
        public int SequenceLength { get; set; }
    }
}
