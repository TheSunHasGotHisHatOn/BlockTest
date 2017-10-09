using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJSS.Api
{
    public class User
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string avatar { get; set; }

        public string createdAt { get; set; }
    }
}