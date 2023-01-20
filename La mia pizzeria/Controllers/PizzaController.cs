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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pizza formData)
        {
            using (RistoranteContext db = new RistoranteContext())
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", formData);
                }
                else
                {
                    db.Pizzas.Add(formData);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (RistoranteContext db = new RistoranteContext())
            {
                //Cerca pizza con determinato parametro nel db
                Pizza pizzaCercata = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                if(pizzaCercata == null)
                {
                    return NotFound("La pizza non è stata trovata");
                }
                return View("Update", pizzaCercata);
            }
        }

        [HttpPost]
        public IActionResult Update(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formData);
            }
            using (RistoranteContext db = new RistoranteContext())
            {
                Pizza pizzaCercata = db.Pizzas.Where(p => p.Id == formData.Id).FirstOrDefault();
                {
                    if(pizzaCercata != null)
                    {
                        pizzaCercata.Title = formData.Title;
                        pizzaCercata.Img = formData.Img;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound("La pizza che volevi modificare non è stato trovato");

                    }
                }
            }
        }

    }


}

