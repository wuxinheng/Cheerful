using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheerful
{
    public class BaseRecord : IBaseRecord
    {
        public DateTime CreateDate { get ; set ; }
        public long CreateBy { get ; set ; }
        public DateTime UpdateDate { get ; set ; }
        public long UpdateBy { get ; set ; }
    }
}