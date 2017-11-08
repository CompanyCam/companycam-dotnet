using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCam
{
    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Permission> permissions { get; set; }
    }
}
