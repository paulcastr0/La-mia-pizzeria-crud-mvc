using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using La_mia_pizzeria.DataBase;
using La_mia_pizzeria.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace La_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            using (RistoranteContext database = new RistoranteContext())
            {
                List<Pizza> ListaDellePizze = database.Pizzas.ToList<Pizza>();

                return View("Index", ListaDellePizze);
            }
        }
    }
}

