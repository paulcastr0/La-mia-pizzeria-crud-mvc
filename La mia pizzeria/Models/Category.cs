﻿using System;
namespace La_mia_pizzeria.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Pizza>? Pizzas { get; set; }
		public Category() { }

	}
}

