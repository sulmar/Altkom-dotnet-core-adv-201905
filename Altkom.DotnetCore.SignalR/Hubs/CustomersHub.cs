using System.Threading.Tasks;
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

        public void Send()
        {
            // this.Clients.Client("ruwerwerw").SendAsync()
        }

    }

}