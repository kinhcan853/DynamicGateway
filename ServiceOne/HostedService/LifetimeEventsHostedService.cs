using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ServiceOne.Https;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceOne.HostedService
{
    public class LifetimeEventsHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpClientGatewaySerrvice _httpClientGateway;
        public LifetimeEventsHostedService(IHostApplicationLifetime appLifetime, IWebHostEnvironment env, IHttpClientGatewaySerrvice httpClientGateway)
        {
            _appLifetime = appLifetime;
            _env = env;
            _httpClientGateway = httpClientGateway;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopped.Register(OnStopped);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _httpClientGateway.RegisterService();
        }

        private void OnStopped()
        {
            _httpClientGateway.DestroyService();
        }
    }
}
