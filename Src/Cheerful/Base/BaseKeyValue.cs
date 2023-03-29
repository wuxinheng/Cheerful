using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheerful
{
    public class BaseKeyValue : IBaseKeyValue
    {
        public string? Key { get ; set ; }
        public string? Value { get ; set ; }
    }
}