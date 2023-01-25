using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using La_mia_pizzeria.DataBase;
using La_mia_pizzeria.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Details(int id)
        {
            using (RistoranteContext db = new RistoranteContext())
            {
                Pizza? pizza = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                if ( pizza == null)
                {
                    return NotFound("La pizza cercata non esiste");
                }
                else
                {
                    return View(pizza);
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (RistoranteContext db = new RistoranteContext())
            {
                List<Category> categoriesFromDB = db.Categories.ToList<Category>();

                PizzaCategoryView modelforView = new PizzaCategoryView();
                modelforView.Pizza = new Pizza();
                modelforView.Categories = categoriesFromDB;
                return View("Create", modelforView);
            }
            
        }

        [HttpPost]
        public IActionResult Create(PizzaCategoryView formData)
        {
            using (RistoranteContext db = new RistoranteContext())
            {
                if (!ModelState.IsValid)
                {
                    List < Category > categories = db.Categories.ToList<Category>();
                    formData.Categories = categories;
                    return View("Create", formData);
                }
                else
                {
                    db.Pizzas.Add(formData.Pizza);
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
                PizzaCategoryView modelforView = new PizzaCategoryView();
                List<Category> categories = db.Categories.ToList<Category>();
                modelforView.Pizza = pizzaCercata;
                modelforView.Categories = categories;

                return View("Update", modelforView);
            }
        }

        [HttpPost]
        public IActionResult Update(int id, PizzaCategoryView formData)
        {
            if (!ModelState.IsValid)
            {
                using (RistoranteContext db = new RistoranteContext())
                {
                    List<Category> categories = db.Categories.ToList<Category>();
                    formData.Categories = categories;
                }
                return View("Update", formData);
            }
            using (RistoranteContext db = new RistoranteContext())
            {
                Pizza pizzaCercata = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                {
                    if(pizzaCercata != null)
                    {
                        pizzaCercata.Title = formData.Pizza.Title;
                        pizzaCercata.Img = formData.Pizza.Img;
                        pizzaCercata.CategoryId = formData.Pizza.CategoryId;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound("La pizza che volevi modificare non è stata trovata");

                    }
                }
            }

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(RistoranteContext db = new RistoranteContext())
            {
                Pizza pizzaToDelete = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();
                if(pizzaToDelete != null)
                {
                    db.Pizzas.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La pizza da eliminare non è stata trovata");
                }
            }
        }

    }


}

