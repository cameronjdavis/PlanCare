
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
                var statuses = Car.Cars.Select(c => new RegoStatus
                {
                    Registration = c.Registration,
                    RegistrationStatus = c.RegistrationStatus
                });
                await regoHub.Clients.All.SendAsync("ReceiveMessage", JsonConvert.SerializeObject(statuses), cancellationToken: stoppingToken);
                await Task.Delay(2000, stoppingToken);
            }
        }

        public class RegoStatus
        {
            public String Registration { get; set; } = String.Empty;
            public String RegistrationStatus { get; set; } = String.Empty;
        }
    }
}
