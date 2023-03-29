using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheerful
{
    public interface IBaseKeyValue
    {
        string? Key { get; set; }
        string? Value { get; set; }
    }
}