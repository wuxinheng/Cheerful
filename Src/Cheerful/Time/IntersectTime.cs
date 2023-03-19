using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful
{
    public class IntersectTime
    {
        public IntersectTime() { }
        public IntersectTime(bool isIntersect, IStartEnd<DateTime>? intersectRange)
        {
            IsIntersect = isIntersect;
            IntersectRange = intersectRange;
        }

        /// <summary>
        /// 是否存在交集
        /// </summary>
        public bool IsIntersect { get; set; }

        /// <summary>
        /// 交叉范围
        /// </summary>
        public IStartEnd<DateTime>? IntersectRange { get; set; }

    }
}
