using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO
{
    public class DefaultModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Deleted { get; set; } = false;
    }
}
