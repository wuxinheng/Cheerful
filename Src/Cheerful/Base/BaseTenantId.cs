using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheerful
{
    public class BaseTenantId : IBaseTenantId
    {
        public long TenantId { get ; set ; }
    }
}