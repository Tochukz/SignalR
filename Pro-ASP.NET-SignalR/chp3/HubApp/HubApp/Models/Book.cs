using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HubApp.Models
{
	public class Book
	{
		public int BookId;
		public string Title;
		public string Author;
		public string Edition;
		public float Price;
		public string Img;
		public int Availability;
		public string Details;
		public int? Pages;
		public string Language;
		public int CategoryId;
		public int SubcategoryId;
		public CategorySt Category;
		public SubcategorySt Subcategory;
	}

	public struct CategorySt
	{
		public int CategoryId;
		public string Category;
	}

	public struct SubcategorySt
	{
		public int SubcategoryId;
		public string Subcategory;
	}
}