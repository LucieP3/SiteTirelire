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
    public class PanierController : Controller
    {
        Commande Panier;

        public PanierController()
        {
            //Récupération du panier depuis le tableau Session
            Panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];

            if (Panier.Client == null)
            {
                Panier.Client = (Client)System.Web.HttpContext.Current.Session["Client"];
                System.Web.HttpContext.Current.Session["Panier"] = Panier;
            }

        }

        // GET: Ajout au panier
        public ActionResult Ajouter(int id)
        {

            //Instanciation d'un Repository Produit pour l'accès au produit
            Repository<Produit> repProduit = new EFRepository<Produit>();


            //Detail concerné par l'ajout
            LigneCommande detail;


            //Recherche d'un produit déjà présent dans le panier, au quel cas, incrémentation de la quantité
            if (Panier.LigneCommandes.Where(d => d.IdProduit == id).Count() > 0)
            {
                detail = Panier.LigneCommandes.Where(d => d.IdProduit == id).First();
                detail.Quantité++;
            }
            else
            {
                detail = new LigneCommande { Produit = repProduit.Trouver(id), IdProduit = id, Quantité = 1 };
                Panier.LigneCommandes.Add(detail);
            }

            //Sauvegarde du Panier
            Session["Panier"] = Panier;


            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {

            return View(Panier);
        }


        public ContentResult Incrementer(int id)
        {
            LigneCommande detailActif = Panier.LigneCommandes.Where(d => d.IdProduit == id).First();

            int? nouvelleQuantite = ++detailActif.Quantité;
            return new ContentResult()
            {
                Content = string.Format("<span>{0}   {1}</span>"
                , detailActif.Quantité.ToString()
                , detailActif.Quantité * detailActif.Produit.PrixHt
                )
            };

        }

        public ContentResult Decrementer(int id)
        {
            LigneCommande detailActif = Panier.LigneCommandes.Where(d => d.IdProduit == id).First();

            if (detailActif.Quantité > 1)
            {
                detailActif.Quantité--;


            }

            return new ContentResult()
            {
                Content = string.Format("<span>{0}         {1}</span>"
                , detailActif.Quantité.ToString()
                , detailActif.Quantité * detailActif.Produit.PrixHt
                )
            };

        }


        public ContentResult Supprimer(int id)
        {
            Panier.LigneCommandes.Remove(Panier.LigneCommandes.Where(d => d.IdProduit == id).First());
            return new ContentResult();
        }


        public ContentResult calculerTotal()
        {
            return new ContentResult
            {
                Content = Panier.LigneCommandes
                .Select(d => new { montant = d.Produit.PrixHt * d.Quantité })
                .Sum(m => m.montant).ToString()
            };
        }

    }
}