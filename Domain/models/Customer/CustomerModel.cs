using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.models
{
    public class CustomerModel
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
    }
}
