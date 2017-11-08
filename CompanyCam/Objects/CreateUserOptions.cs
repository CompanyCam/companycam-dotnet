using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CompanyCam.Objects;
using CompanyCam.Services;
using Newtonsoft.Json;

namespace CompanyCam
{
    public class CreateUserOptions
    {
        public string email_address { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
    }
}
