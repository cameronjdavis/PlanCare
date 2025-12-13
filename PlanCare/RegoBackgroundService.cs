
using Microsoft.AspNetCore.SignalR;
using PlanCare.Hubs;

namespace PlanCare
{
    public class RegoBackgroundService(IHubContext<RegoHub> regoHub) : BackgroundService
    {
        private readonly IHubContext<RegoHub> regoHub = regoHub;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await regoHub.Clients.All.SendAsync("ReceiveMessage", "user2", "rego something klnam", cancellationToken: stoppingToken);

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
