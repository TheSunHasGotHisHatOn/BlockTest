﻿using System;
using System.Net;
using Newtonsoft.Json;

namespace BJSS.ReqresApi
{
    public class ReqresResponse
    {
        [JsonProperty("data")]
        public User User { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string RawResponse { get; set; }

        public void LogTrace()
        {
            Console.WriteLine("RawResponse: {0}", RawResponse);
            // todo: tech debt - it would be good to get the request in here too, maybe using fiddlercore and the time the request took.
            // Console.WriteLine("Request: {0}", "nothing here yet");
            // Console.WriteLine("TimeTaken: {0}", "nothing here yet");
        }
    }
}