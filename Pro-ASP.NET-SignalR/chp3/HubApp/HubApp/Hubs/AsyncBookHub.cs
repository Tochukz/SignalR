using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using HubApp.Models;

namespace HubApp.Hubs
{
	[HubName("BookHub")]
	public class AsyncBookHub: Hub<IBookClient>
	{
		HttpClient HttpClient;

		public static IEnumerable<CategorySt> Categories;

		public static IEnumerable<SubcategorySt> Subcategories;

		public AsyncBookHub()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			HttpClient = new HttpClient();
		}

		public async Task<Book> GetBook(int bookId)
		{						
			try
			{
				HttpResponseMessage responseMessage = await HttpClient.GetAsync($"https://api.ojlinks.tochukwu.xyz/api/books/{bookId}");				
				if (!responseMessage.IsSuccessStatusCode)
				{
					throw new ServiceException { ErrorMessage = $"{responseMessage.ReasonPhrase} {responseMessage.StatusCode}" };
				}
				using (HttpContent content = responseMessage.Content)
				{
					string jsonString = await content.ReadAsStringAsync();
					Book book = JsonConvert.DeserializeObject<Book>(jsonString);
					book.Img = $"https://ojlinks.tochukwu.xyz/storage/book_img/{book.Img}";
					IEnumerable<CategorySt> categories = await GetCategories();
					IEnumerable<SubcategorySt> subcategories = await GetSubcategories();
					book.Category = categories.First(cat => cat.CategoryId == book.CategoryId);
					book.Subcategory = subcategories.First(sub => sub.SubcategoryId == book.SubcategoryId);
					return book;
				}
			}						
			catch(Exception exception)
			{
				Clients.Caller.SignalError(exception.InnerException);
				throw exception;
			}

		}

		public async Task<IEnumerable<CategorySt>> GetCategories()
		{
			try
			{
				if (Categories != null)
				{
					return Categories;
				}
				HttpResponseMessage responseMessage = await HttpClient.GetAsync("https://api.ojlinks.tochukwu.xyz/api/categories");
				if (!responseMessage.IsSuccessStatusCode)
				{
					throw new ServiceException { ErrorMessage = $"{responseMessage.StatusCode}" };
				}
				using (HttpContent content = responseMessage.Content)
				{
					string jsonString = await content.ReadAsStringAsync();
					Categories = JsonConvert.DeserializeObject<IEnumerable<CategorySt>>(jsonString);					
					return Categories;
				}
			}
			catch(Exception exception)
			{
				Clients.Caller.SignalError(exception.InnerException);
				throw exception;
			}
		}

		public async Task<IEnumerable<SubcategorySt>> GetSubcategories()
		{
			try
			{
				if (Subcategories != null)
				{
					return Subcategories;
				}
				HttpResponseMessage responseMessage = await HttpClient.GetAsync("https://api.ojlinks.tochukwu.xyz/api/subcategories");
				if (!responseMessage.IsSuccessStatusCode)
				{
					throw new ServiceException { ErrorMessage = $"{responseMessage.StatusCode}" };
				}
				using (HttpContent content = responseMessage.Content)
				{
					string jsonString = await content.ReadAsStringAsync();
					Subcategories = JsonConvert.DeserializeObject<IEnumerable<SubcategorySt>>(jsonString);
					return Subcategories;
				}
			}
			catch (Exception exception)
			{
				Clients.Caller.SignalError(exception.InnerException);
				throw exception;
			}
		}
	}

	public interface IBookClient
	{
	    void SignalError(Exception exception);
	}

	public class ServiceException : Exception
	{
		public string ErrorMessage {get; set;}
	}
	
}