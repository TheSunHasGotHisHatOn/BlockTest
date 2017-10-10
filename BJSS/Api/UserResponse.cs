using System.Net;
using Newtonsoft.Json;

namespace BJSS.Api
{
    public class UserResponse
    {
        [JsonProperty("data")]
        public User User { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string RawResponse { get; set; }
    }
}
