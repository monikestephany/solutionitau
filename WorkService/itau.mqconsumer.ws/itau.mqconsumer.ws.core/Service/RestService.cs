using itau.mqconsumer.ws.core.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace itau.mqconsumer.ws.core.Service
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public bool Post(string uri,string mensagem) 
        {         
            var result = _client.PostAsync(uri, new StringContent(mensagem, Encoding.UTF8, "application/json")).Result;
            return result.StatusCode == HttpStatusCode.Created;
        }
    }
}
