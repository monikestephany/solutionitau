﻿namespace itau.doc.ext.api.core.Contracts
{
    public interface IRabbitConfiguration
    {
        string Host { get; set; }
        string Password { get; set; }
        int Port { get; set; }
        string Queue { get; set; }
        string RoutingKey { get; set; }
        string User { get; set; }
        string Exchange { get; set; }
    }
}