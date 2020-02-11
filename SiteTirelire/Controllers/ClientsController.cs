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
    public class ClientController : Controller
    {
        //Instanciation d'un repository Commande 
        Repository<Commande> repCommande = new EFRepository<Commande>();

        Repository<Client> repClient = new EFRepository<Client>();

        // GET: Client
        public ActionResult ListerCommandes()
        {

            int id = ((Client)Session["Client"]).IdClient;
            return View(repCommande.Lister().Where(c => c.IdClient == id));
        }


        public ActionResult DetailCommande(int id)
        {

            return View(repCommande.Trouver(id));
        }


        public ActionResult DeposerAvis(int id)
        {

            Avi nouvelAvis = new Avi
            {
                IdProduit = id
                ,
                IdClient = ((Client)Session["Client"]).IdClient
                ,
                Etape = (int)EtatsAvis.NonApprouve
                ,
                Notation = 3
                ,
                Date = DateTime.Now
            };

            return View(nouvelAvis);

        }

        [HttpPost]
        public ActionResult DeposerAvis(Avi avis)
        {
            //instanciation d'un repository Avis
            Repository<Avi> repAvis = new EFRepository<Avi>();
            repAvis.Ajouter(avis);

            return RedirectToAction("ListerCommandes", new { id = avis.IdClient });
        }

        public ActionResult Monprofil()

        {
            Client Monprofil = new Client
            {

                IdClient = ((Client)Session["Client"]).IdClient,
                Nom = ((Client)Session["Client"]).Nom,
                Prénom = ((Client)Session["Client"]).Prénom,
                Email = ((Client)Session["Client"]).Email,

            };
            return View(Monprofil);
        }

        





        public ActionResult Edit (int id)
        {
            return View(repClient.Trouver(id));
        }

        [HttpPost]
        public ActionResult Edit (Client client)
        {
            try
            {
                repClient.Modifier(client);
                return RedirectToAction("Edit");

            }
            catch
            {
                return View();
            }
        }

       



    }
}
