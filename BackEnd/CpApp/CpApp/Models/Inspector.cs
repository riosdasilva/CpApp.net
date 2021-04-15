using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Models
{
    public class Inspector : User
    {
        public ICollection<Ticket> Tickets { get; set; }
    }
}
