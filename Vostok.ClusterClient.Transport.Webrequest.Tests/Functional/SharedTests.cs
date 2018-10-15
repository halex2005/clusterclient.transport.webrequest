﻿using System;
using Vostok.Clusterclient.Core.Transport;
using Vostok.Clusterclient.Transport.Tests.Shared.Functional;
using Vostok.Clusterclient.Transport.Webrequest;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Console;

namespace Vostok.ClusterClient.Transport.Webrequest.Tests.Functional
{
    public class Config : ITransportTestConfig
    { 
        public ILog CreateLog() => new ConsoleLog();

        public ITransport CreateTransport(TestTransportSettings settings, ILog log)
        {
            var transportSettings = new WebRequestTransportSettings
            {
                UseResponseStreaming = settings.UseResponseStreaming,
                Proxy = settings.Proxy,
                BufferFactory = settings.BufferFactory,
                ConnectionAttempts = settings.ConnectionAttempts,
                AllowAutoRedirect = settings.AllowAutoRedirect,
                MaxResponseBodySize = settings.MaxResponseBodySize,
                MaxConnectionsPerEndpoint = settings.MaxConnectionsPerEndpoint
            };
            return new WebRequestTransport(transportSettings, log);
        }

        public TestTransportSettings CreateDefaultSettings() => new TestTransportSettings
        {
            MaxConnectionsPerEndpoint = 10 * 1000,
            ConnectionAttempts = 2,
            BufferFactory = size => new byte[size],
            UseResponseStreaming = _ => false
        };
    }

    internal class AllowAutoRedirectTests : AllowAutoRedirectTests<Config>
    {
    }
    internal class ClientTimeoutTests : ClientTimeoutTests<Config>
    {
    }
    internal class ConnectionFailureTests : ConnectionFailureTests<Config>
    {
    }
    internal class ConnectionTimeoutTests : ConnectionTimeoutTests<Config>
    {
    }
    internal class ContentReceivingTests : ContentReceivingTests<Config>
    {
    }
    internal class ContentSendingTests : ContentSendingTests<Config>
    {
    }
    internal class HeaderReceivingTests : HeaderReceivingTests<Config>
    {
    }
    internal class HeaderSendingTests : HeaderSendingTests<Config>
    {
    }
    internal class MaxConnectionsPerEndpointTests : MaxConnectionsPerEndpointTests<Config>
    {
    }
    internal class MethodSendingTests : MethodSendingTests<Config>
    {
    }
    internal class ProxyTests : ProxyTests<Config>
    {
    }
    internal class QuerySendingTests : QuerySendingTests<Config>
    {
    }
    internal class RequestCancellationTests : RequestCancellationTests<Config>
    {
    }
    internal class StatusCodeReceivingTests : StatusCodeReceivingTests<Config>
    {
    }
}