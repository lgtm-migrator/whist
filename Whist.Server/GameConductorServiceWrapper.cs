namespace Whist.Server
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;

    public sealed class GameConductorServiceWrapper : IHostedService
    {
        private readonly GameConductorService _gameConductorService;

        public GameConductorServiceWrapper(GameConductorService gameConductorService)
        {
            this._gameConductorService = gameConductorService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return this._gameConductorService.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return this._gameConductorService.StopAsync(cancellationToken);
        }
    }
}