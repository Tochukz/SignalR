using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using System.Net;

namespace ConsoleClient
{
	class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("Do you want to connect?");
			string response = Console.ReadLine();
			if (response.ToLower() == "y" || response.ToLower() == "yes")
			{
			    Connection connection = Connect();
				Console.WriteLine($"Connected with ID {connection.ConnectionId}");
			}
			Console.WriteLine("Type anything to exit");
			Console.ReadLine();
		}

		static Connection Connect()
		{
			Dictionary<string, string> query = new Dictionary<string, string>();
			query["name"] = "Chucks";
			Connection connection = new HubConnection("https://localhost:44304", query);
			connection.Headers.Add("X-Client-Name", "Console-Client");
			connection.CookieContainer = new CookieContainer();
			connection.CookieContainer.Add(new Cookie("MyCookie", "chuck275", "/", "https://localhost:44304"));
			return connection;
		}
	}
}
