using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BJSS.Api
{
    public class GetUserResponse
    {
        public User data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
