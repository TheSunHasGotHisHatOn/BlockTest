using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BJSS.Api
{
    public class UserResponse
    {
        public User User { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
