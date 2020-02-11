using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteTirelire.Models;
using SiteTirelire.DataAccess;

namespace SiteTirelire.Controllers
{
    public class CategorieController : Controller
    {
        //Instanciation d'un Repository de type Categorie
        Repository<Categorie> repCategorie = new EFRepository<Categorie>();

        // GET: Categorie
        public ActionResult Index()
        {
            return View(repCategorie.Lister());
        }

        // GET: Categorie/Details/5
        public ActionResult Details(int id)
        {
            return View(repCategorie.Trouver(id));
        }

        // GET: Categorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        [HttpPost]
        public ActionResult Create(Categorie categorie)
        {
            try
            {
                repCategorie.Ajouter(categorie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorie/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repCategorie.Trouver(id));
        }

        // POST: Categorie/Edit/5
        [HttpPost]
        public ActionResult Edit(Categorie categorie)
        {
            try
            {

                repCategorie.Modifier(categorie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categorie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Categorie categorieASupprimer = repCategorie.Trouver(id);
                categorieASupprimer.Statut = 0;
                repCategorie.Modifier(categorieASupprimer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
