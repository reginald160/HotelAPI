using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeHotelAPI.Helper
{
    public class HelperAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:49911"); //This is the WebAPI URI address copy return
            return Client;
        }
    }
}
