using superHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace superHeroes.Controllers
{
    public class SuperHeroController : Controller
    {
        private ApplicationDbContext db;
        // GET: SuperHero
        public SuperHeroController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            return View(db.SuperHeroes.Where((x) => x.id == id).FirstOrDefault());
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero hero = new SuperHero();
            return View(hero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHero hero)
        {
            try
            {
                // TODO: Add insert logic here
                db.SuperHeroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
