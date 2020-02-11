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
    public class CommandeController : Controller
    {
        Commande Panier;
        //Instanciation d'un repository de commande
        CommandeRepository repCommande = new CommandeRepository();

        //Présente un résumé du client et de son panier pour confirmation
        public ActionResult Confirmation()
        {
            //Injection du total de la commande dans le ViewBag
            ViewBag.Total = float.Parse((new PanierController()).calculerTotal().Content);
            Panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];
            Panier.PrixTTC = float.Parse((new PanierController()).calculerTotal().Content);
            Session["Panier"] = Panier;

            return View((Commande)System.Web.HttpContext.Current.Session["Panier"]);
        }


        public ActionResult Validation()
        {
            //Instanciation d'un repository de commande spécifique
            CommandeRepository repCommande = new CommandeRepository();

            //Récupération du panier
            Commande Panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];

            try
            {
                //Persistence du PAnier en table des commandes
                Commande cde = repCommande.Ajouter(Panier);


                //Réinitialisation du panier puisque le précédent à fait l'objet d'une commande
                System.Web.HttpContext.Current.Session["Panier"] = new Commande();

                //Vue de remerciements
                return View("Validation", Panier);

            }
            catch (Exception ex)
            {

                throw;
            }

        }



        public ActionResult Lister()
        {
            return View(repCommande.Lister().Where(c => c.StatutCommande > 0));
        }

        public ActionResult Details(int id)
        {

            return View(repCommande.Trouver(id));
        }

        public ContentResult Supprimer(int id)
        {

            Commande commandeADesactiver = repCommande.Trouver(id);
            commandeADesactiver.StatutCommande = (int)EtatsCommande.Inactive;
            repCommande.Modifier(commandeADesactiver);
            return new ContentResult { Content = ((EtatsCommande)commandeADesactiver.StatutCommande).ToString() };
        }


        public ContentResult Suspendre(int id)
        {

            Commande commandeASuspendre = repCommande.Trouver(id);
            commandeASuspendre.StatutCommande = (int)EtatsCommande.Suspendue;
            repCommande.Modifier(commandeASuspendre);
            return new ContentResult { Content = ((EtatsCommande)commandeASuspendre.StatutCommande).ToString() };
        }


        public ContentResult Traiter(int id)
        {

            Commande commandeATraiter = repCommande.Trouver(id);

            //On passe à l'état suivant jusqu'à 'Receptionnée'

            if (commandeATraiter.StatutCommande < (int)EtatsCommande.Receptionnee)
            {

                commandeATraiter.StatutCommande++;
                //Sauvegarde
                repCommande.Modifier(commandeATraiter);

            }
            else if (commandeATraiter.StatutCommande == (int)EtatsCommande.Suspendue)
            {
                commandeATraiter.StatutCommande = (int)EtatsCommande.Active;
                //Sauvegarde
                repCommande.Modifier(commandeATraiter);
            }


            return new ContentResult { Content = ((EtatsCommande)commandeATraiter.StatutCommande).ToString() };


        }





    }


}
