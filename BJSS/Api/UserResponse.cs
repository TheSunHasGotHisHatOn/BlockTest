using System.Net;

namespace BJSS.Api
{
    public class UserResponse
    {
        public User User { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
