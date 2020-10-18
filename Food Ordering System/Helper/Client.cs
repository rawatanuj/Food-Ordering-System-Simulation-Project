using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Food_Ordering_System.Helper
{
    public class Client
    {
        public HttpClient MenuItemDetails()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:53086");
            return client;
        }

        public HttpClient CategoryDetails()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63200");
            return client;
        }
        public HttpClient AuthClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50005");
            return client;
        }
    }
}
