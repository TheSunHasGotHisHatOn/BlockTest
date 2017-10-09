using System.Net;

namespace BJSS.Api
{
    public class GetUserResponse
    {
        public User data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
