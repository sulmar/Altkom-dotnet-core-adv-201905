using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.SenderClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // dotnet add package Microsoft.AspNetCore.SignalR.Client

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Signal-R Sender!");

            const string url = "http://localhost:5000/hubs/customers";

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            connection.Closed += ex => Task.Run(() => System.Console.WriteLine($"ERROR {ex.Message}"));

            System.Console.WriteLine("Connecting...");
            await connection.StartAsync();
            System.Console.WriteLine("Connected.");

            Customer customer = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            while (true)
            {

                await connection.SendAsync("CustomerAdded", customer);

                Console.WriteLine($"Sent {customer.FirstName}");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Console.ResetColor();

            Console.WriteLine("Press any enter to exit.");
            Console.ReadLine();






        }
    }
}
