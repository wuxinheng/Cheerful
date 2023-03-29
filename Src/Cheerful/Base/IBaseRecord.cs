using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheerful
{
    public interface IBaseRecord
    {
        DateTime CreateDate { get; set; }
        long CreateBy { get; set; }
        DateTime UpdateDate { get; set; }
        long UpdateBy { get; set; }
    }
}