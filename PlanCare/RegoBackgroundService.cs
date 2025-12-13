
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PlanCare.Hubs;
using PlanCare.Model;

namespace PlanCare
{
    public class RegoBackgroundService(IHubContext<RegoHub> regoHub) : BackgroundService
    {
        private readonly IHubContext<RegoHub> regoHub = regoHub;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await regoHub.Clients.All.SendAsync("ReceiveMessage", "user2", JsonConvert.SerializeObject(Car.Cars), cancellationToken: stoppingToken);
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
