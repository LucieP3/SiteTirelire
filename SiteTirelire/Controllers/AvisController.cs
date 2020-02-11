using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiteTirelire.DataAccess;
using SiteTirelire.Models;
using SiteTirelire.Outils;

namespace SiteTirelire.Controllers
{
    [Authorize]
    public class AvisController : Controller
    {

        //Instanciation du EFRepository pour l'entité Avis
        Repository<Avi> repAvis = new EFRepository<Avi>();

        // GET: Avis
        public ActionResult Index()
        {
            //Pour la modération, seul les avis nonValidés sont à exposer
            return View(repAvis.Lister().Where(a => a.Etape == (int)EtatsAvis.NonApprouve));
        }

        // GET: Avis/Details/5
        public ActionResult Details(int id)
        {
            return View(repAvis.Trouver(id));
        }





        // GET: Avis/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repAvis.Trouver(id));
        }

        // POST: Avis/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                repAvis.Supprimer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ContentResult Approuver(int id)
        {

            Avi avisAApprouver = repAvis.Trouver(id);
            avisAApprouver.Etape = (int)EtatsAvis.Approuve;
            repAvis.Modifier(avisAApprouver);
            return new ContentResult { Content = ((EtatsAvis)avisAApprouver.Etape).ToString() };
        }


        public ContentResult Refuser(int id)
        {

            Avi avisARefuser = repAvis.Trouver(id);
            avisARefuser.Etape= (int)EtatsAvis.Rejete;
            repAvis.Modifier(avisARefuser);
            return new ContentResult { Content = ((EtatsAvis)avisARefuser.Etape).ToString() };
        }


    }
}
