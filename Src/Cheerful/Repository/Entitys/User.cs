using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful.Repository.Entitys
{
    public class User : IBaseId, IBaseName, IBaseNo
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        [BuildCode(Prefix ="PO",Postfix ="Test",SequenceLength =4)]
        public string? No { get; set; }
    }
}
