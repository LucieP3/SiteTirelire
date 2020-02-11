using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(LigneCommandeMetaData))]
    public partial class LigneCommande { }
    public class LigneCommandeMetaData
    {
        Commande Commande { get; set; }
        
        [DisplayName("Commande de la ligne de commande")]
        public int IdCommande { get; set; }
        
        [DisplayName("Ligne de commande")]
        public int IdLigneCommande { get; set; }
        
        [DisplayName("Produit dans la ligne de commande")]
        public int IdProduit { get; set; }
        Produit Produit { get; set; }
        
        [DisplayName("Quantité du produit de la ligne de commande")]
        public int Quantité { get; set; }

        [DisplayName("Prénom du client")]
        public string NomProduit { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Prix unitaire du produit de la ligne de commande")]
        public double PrixUnitaire { get; set; }
    }
}