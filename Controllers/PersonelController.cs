﻿using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVC.Models.ViewModels;

namespace PersonelMVC.Controllers
{
    [Authorize(Roles = "A,U")]


    public class PersonelController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();


        [OutputCache(Duration =30)]

        // GET: Personel
        public ActionResult Index()
        {
            var model = db.Personel.Include(x => x.Departman).ToList();
            return View(model);

        }
        [Authorize(Roles ="A")]

        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                departmanlar = db.Departman.ToList()
            };
            return View("PersonelForm");

        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonelFormViewModel()
                {
                    departmanlar = db.Departman.ToList(),
                    Personel = personel
                };
                return View("PersonelForm", model);
            }

            if (personel.Id==0)

            {
                db.Personel.Add(personel);
            }
            else
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Guncelle(int id)

        {
            var model = new PersonelFormViewModel()
            {
                departmanlar =db.Departman.ToList(),
                Personel=db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekPersonel = db.Personel.Find(id);
            if (silinecekPersonel==null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PersonelleriListele(int id)
        {

            var model = db.Personel.Where(x => x.DepartmanId == id);

            return PartialView(model);

        }
        public ActionResult ToplamMaas()
        {

            ViewBag.Maas = db.Personel.Sum(x => x.Maas);
            return PartialView();


        }

    }
}