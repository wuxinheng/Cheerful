using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheerful
{
    public interface IBaseTenantId
    {
        long TenantId { get; set; }
    }
}