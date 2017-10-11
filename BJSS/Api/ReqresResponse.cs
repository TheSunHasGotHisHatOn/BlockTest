using System.Net;
using Newtonsoft.Json;

namespace BJSS.Api
{
    public class ReqresResponse
    {
        [JsonProperty("data")]
        public User User { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string RawResponse { get; set; }
    }
}
