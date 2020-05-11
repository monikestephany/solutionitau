using System;
using System.Collections.Generic;
using System.Text;

namespace itau.mqconsumer.ws.core.Contracts
{
    public interface IRestService
    {
        bool Post(string uri, string mensagem);
    }
}
