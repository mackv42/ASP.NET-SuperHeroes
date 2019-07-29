﻿using superHeroes.Models;
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
        public ActionResult Home()
        {
            return RedirectToAction("List");
        }
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            
            return View(db.SuperHeroes.OrderBy(x=>-x.clicks));
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int? id)
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
                db.SuperHeroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                return View(db.SuperHeroes.Where(x => x.id == id).FirstOrDefault());
            }
            catch
            {
                //Need a 404 page
                return RedirectToAction("Index");
            }
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(SuperHero hero)
        {
            try
            {
                // TODO: Add update logic here
                SuperHero modify = db.SuperHeroes.Where(x => x.id == hero.id ).FirstOrDefault();
                modify.name = hero.name;
                modify.catchPhrase = hero.catchPhrase;
                modify.alterEgo = hero.alterEgo;
                modify.primaryAbility = hero.primaryAbility;
                modify.secondaryAbility = hero.secondaryAbility;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                return View(db.SuperHeroes.Where(x => x.id == id).FirstOrDefault());
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public void Delete(SuperHero hero)
        {
            SuperHero removedHero = db.SuperHeroes.Where(x => x.id == hero.id).FirstOrDefault();
            db.SuperHeroes.Remove(removedHero);
            db.SaveChanges();
           
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public void Click(int id)
        {
            SuperHero hero = db.SuperHeroes.Where(x => x.id == id).FirstOrDefault();
            hero.clicks++;
            db.SaveChanges();
        }


        [HttpPost]
        public ActionResult uploadImage(int? id, HttpPostedFileBase file)
        {
            SuperHero hero = db.SuperHeroes.Where(x => x.id == id).FirstOrDefault();
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("/Images/")
                                                              + file.FileName);
                        hero.imgPath = file.FileName;
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception E)
            {
                return RedirectToAction("Edit/"+id.ToString());
            }
            return RedirectToAction("Edit/"+id.ToString());
        }
    }
}
