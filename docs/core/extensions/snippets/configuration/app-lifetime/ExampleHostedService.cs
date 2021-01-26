using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppLifetime.Example
{
    public class ExampleHostedService : IHostedService
    {
        private readonly ILogger _logger;

        public ExampleHostedService(
            ILogger<ExampleHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
            _logger = logger;

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartAsync が呼び出されました。");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("4. StopAsync が呼び出されました。");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("2. OnStarted が呼び出されました。");
        }

        private void OnStopping()
        {
            _logger.LogInformation("3. OnStopping が呼び出されました。");
        }

        private void OnStopped()
        {
            _logger.LogInformation("5. OnStopped が呼び出されました。");
        }
    }
}
