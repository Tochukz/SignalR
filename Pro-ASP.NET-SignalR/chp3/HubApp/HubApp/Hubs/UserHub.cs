using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace HubApp.Hubs
{

	public class UserHub: Hub<IClientUser>
	{
		public static List<User> Users;
		public static int CurrentId;

		public void AddUser(string name, string city)
		{
			if (Users == null)
			{
				Users = new List<User>();
			}
			CurrentId++;
			User newUser = new User { UserId = CurrentId, Name = name, City = city };
			Users.Add(newUser);
			Clients.All.NewUser(newUser);			
		}

		public void AddUser(User user)
		{
			user.UserId = ++CurrentId;
			Clients.All.NewUser(user);
		}

		public List<User> GetAllUsers()
		{
			return Users;
		}

		public void DeleteUser(int userId)
		{
			IEnumerable<User> users = Users.Where(usr => usr.UserId == userId);
			if (users.Count() > 0)
			{
				User user = Users.First(usr => usr.UserId == userId);
				Users.Remove(user);
			}			
			Clients.Others.RemoveUser(userId);
		}
	}

	public interface IClientUser
	{
		void NewUser(User user);
		void RemoveUser(int UserId);
	}

	public struct User
	{
		public int UserId;
		public string Name;
		public string City;
	}
}