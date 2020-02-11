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
using System.IO;
using System.Threading.Tasks;
using SiteTirelire.Outils;

namespace SiteTirelire.Controllers
{
    public class ProduitController : Controller
    {

        //Instanciation du EFRepository pour l'entité Produit
        Repository<Produit> repProduit = new EFRepository<Produit>();

        //top produit
        Repository<LigneCommande> repLigneCommande = new EFRepository<LigneCommande>();
        public ActionResult TopProduit()
        {
            var query = repLigneCommande.Lister().GroupBy(x => x.IdProduit).Select(g => new { idprod = g.Key, total = g.Sum(x => x.Quantité) }).ToList().OrderByDescending(g => g.total);
          
            List<TotalProduit> ListProd = new List<TotalProduit>();

            foreach (var itemquery in query)
            {
                TotalProduit item = new TotalProduit();
                item.IdProduit = (int)itemquery.idprod;
                item.QuantitéTotal = (int)itemquery.total;
                item.NomProduit = repProduit.Trouver(item.IdProduit).NomProduit;
                item.chemin = repProduit.Trouver(item.IdProduit).Chemin;
                ListProd.Add(item);
            }
            TotalGlobal model = new TotalGlobal()
            {
                ListIds = ListProd
            };
            return View(model);
        }




        //Fournir une list de SelectListItem pour alimentation des DropDownList Fournisseur
        private void FormerListeFournisseurs()
        {
            //Instanciation d'un repository pour les fournisseurs
            Repository<Fournisseur> repFournisseur = new EFRepository<Fournisseur>();

            ViewBag.IDFournisseur = repFournisseur.Lister()
                .Select(f =>
                new SelectListItem { Value = f.IdFournisseur.ToString(), Text = f.Nom })
                .ToList<SelectListItem>();
        }

        //Fournir une list de SelectListItem pour alimentation des DropDownList Categorie
        private void FormerListeCategories()
        {
            //Instanciation d'un repository pour les categories
            Repository<Categorie> repCateg = new EFRepository<Categorie>();

            ViewBag.IDCategorie = repCateg.Lister()
                .Select(c =>
                new SelectListItem { Value = c.IdCategorie.ToString(), Text = c.Description })
                .ToList<SelectListItem>();
        }




        //Méthode de retour de la Galerie Produit pour les clients
        public ActionResult Galerie()
        {
            return View(repProduit.Lister().Where(p => p.Stock >= 1));
        }

        public ActionResult GaleriePink()
        {
            return View(repProduit.Lister().Where(p => p.Categorie.NomCategorie == "Pink"));
        }

        public ActionResult GalerieBlack()
        {
            return View(repProduit.Lister().Where(p => p.Categorie.NomCategorie == "Black"));
        }


        // GET: Produit
        public ActionResult Index()
        {
            return View(repProduit.Lister());
        }

        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            return View(repProduit.Trouver(id));
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            FormerListeCategories();
            FormerListeFournisseurs();
            return View();
        }


        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(Produit produit, HttpPostedFileBase fichier)
        {
            try
            {
                if (fichier != null)
                {
                    produit.Chemin = Path.GetFileName(fichier.FileName);
                }

                Produit nouveau = repProduit.Ajouter(produit);

                if (fichier != null)
                {
                    //L'Id du produit est ajouté pour éviter les doublons de noms de fichiers
                    string destination = string.Format("{0}\\{1}_{2}"
                        , System.Web.Hosting.HostingEnvironment.MapPath("~/Images")
                        , nouveau.IdProduit
                        , nouveau.Chemin
                        );
                    fichier.SaveAs(destination);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                FormerListeFournisseurs();
                FormerListeCategories();
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            FormerListeFournisseurs();
            FormerListeCategories();
            return View(repProduit.Trouver(id));
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit produit, HttpPostedFileBase fichier)
        {


            try
            {
                //Détermination du chemin précédent
                string anciennomfichier = produit.Chemin;

                if (fichier != null)
                {
                    produit.Chemin = Path.GetFileName(fichier.FileName);

                }

                Produit p = repProduit.Modifier(produit);

                if (fichier != null)
                {
                    //Reconstitution du chemin précédent
                    if (p.Chemin != null)
                    {
                        string ancienfichier = string.Format("{0}\\{1}_{2}"
                            , Server.MapPath("~/Images")
                            , p.IdProduit
                            , anciennomfichier
                            );

                        if (System.IO.File.Exists(ancienfichier))
                        {
                            System.IO.File.Delete(ancienfichier);

                        }

                    }

                    string destination = string.Format("{0}\\{1}_{2}"
                       , System.Web.Hosting.HostingEnvironment.MapPath("~/Images")
                       , p.IdProduit
                       , p.Chemin
                       );
                    fichier.SaveAs(destination);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                FormerListeFournisseurs();
                FormerListeCategories();
                return View();
            }
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produit/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                if (repProduit.Supprimer(id)) return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }



        



    }
}
