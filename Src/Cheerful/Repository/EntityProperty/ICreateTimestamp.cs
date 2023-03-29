using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful.Repository.EntityProperty
{
    public interface ICreateTimestamp
    {
        int CreateTimestamp { get; set; }

        [NotMapped]
        DateTime CreateDateTime { get; set; }
    }
}
