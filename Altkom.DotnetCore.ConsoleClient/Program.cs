using System;
using System.Threading.Tasks;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Altkom.DotnetCore.ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            const string url = "http://localhost:5000/hubs/customers";

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;

            // dotnet add package Microsoft.AspNetCore.SignalR.Client
            Console.WriteLine("Singal-R Client!");

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            connection.Closed +=  ex => Task.Run(()=>System.Console.WriteLine($"ERROR {ex.Message}")); 

            System.Console.WriteLine("Connecting...");
            await connection.StartAsync();            
            System.Console.WriteLine("Connected.");

            connection.On<Customer>("Added", 
                customer => Console.WriteLine($"Added customer {customer.FirstName}"));

            System.Console.WriteLine("Press enter to exit.");

            Console.ReadLine();

            Console.ResetColor();

        }


    }
}
