using System;

namespace La_mia_pizzeria.Models
	
{
	public class Pizza
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Img { get; set; }
		public string? Description { get; set; }

		public int? CategoryId { get; set; }
		public Category? Category { get; set; }

		public Pizza() { }

		

    }
	
}

