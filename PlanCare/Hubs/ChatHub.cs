using Microsoft.AspNetCore.SignalR;

namespace PlanCare.Hubs
{
    public class RegoHub : Hub
    {
        //public async Task ReceiveMessage(string user, string message)
        //{
        //    var rego = Context.GetHttpContext()?.Request.Query["rego"].ToString();
        //    await Clients.All.SendAsync("ReceiveMessage", user, rego);
        //}
    }
}
