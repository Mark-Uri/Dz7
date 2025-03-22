using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    [Keyless] 
    public class UserOrderView
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public int? OrderId { get; set; }
        

        public DateTime? OrderDate { get; set; }
    }
}
