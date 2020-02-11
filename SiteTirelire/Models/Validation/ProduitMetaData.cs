using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(ProduitMetaData))]
    public partial class Produit { }
    public class ProduitMetaData
    {

        
        ICollection<Avi> Avis { get; set; }

       
        [DisplayName("Capacité du produit")]
        [Required(ErrorMessage ="Merci de renseigner la capacité du produit")]
        public int Capacité { get; set; }
        Categorie Categorie { get; set; }

        [DisplayName("url du produit")]
        public string Chemin { get; set; }



        [DisplayName("La description du produit")]
        [Required(ErrorMessage ="Merci de renseigner la description du produit")]
        public string Description { get; set; }
        Fournisseur Fournisseur { get; set; }
        
        [DisplayName("Catégorie du produit")]
        public int? IdCategorie { get; set; }
        
        [DisplayName("Fournisseur du produit")]
        public int? IdFournisseur { get; set; }
        
        [DisplayName("Produit")]
        public int IdProduit { get; set; }

        [DisplayName("Nom du produit")]
        public string NomProduit { get; set; }
        ICollection<LigneCommande> LigneCommandes { get; set; }
        
        [DisplayName(" Prix hors taxes du produit ")]
        [Required(ErrorMessage ="Merci de renseigner le prix hors taxes du produit")]
        [DataType(DataType.Currency)]
        public double PrixHt { get; set; }
       
        
        [DisplayName("Statut du stock du produit")]
        public int Stock { get; set; }
        
        [DisplayName("Hauteur du produit")]
        public double Hauteur { get; set; }
        [DisplayName("Largeur du produit")]
        public double Largeur { get; set; }
    }
}