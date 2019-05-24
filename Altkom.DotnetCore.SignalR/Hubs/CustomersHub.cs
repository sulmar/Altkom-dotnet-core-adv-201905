using System.Threading.Tasks;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.SignalR;

namespace Altkom.DotnetCore.SignalR
{

    public class CustomersHub : Hub
    {
        public override async Task OnConnectedAsync() 
        {
            // this.Context.ConnectionId
            await base.OnConnectedAsync();
        }

        public void CustomerAdded(Customer customer)
        {
            this.Clients.Others.SendAsync("Added", customer);
             // this.Clients.Client("ruwerwerw").SendAsync()
        }

    }

}