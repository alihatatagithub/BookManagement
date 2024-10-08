using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Api.SignalRHubs
{
    public class EmployeeHub : Hub
    {
        public async Task AddEmployeeNotifer(string message = "hi")
        {
            await Clients.All.SendAsync("Receive",message);

        }
    }
}
