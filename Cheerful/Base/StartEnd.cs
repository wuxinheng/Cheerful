using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful
{
    public class StartEnd<T> : IStartEnd<T>
    {
        public StartEnd() { }
        public StartEnd(T start, T end)
        {
            Start=start;
            End=end;
        }
        public T Start { get; set; }
        public T End { get; set; }
    }
}
