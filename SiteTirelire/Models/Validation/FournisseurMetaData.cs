using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(FournisseurMetaData))]
    public partial class Fournisseur { }
    public class FournisseurMetaData
    {
        [DisplayName("Adresse du fournisseur")]
        public string Adresse { get; set; }
        
        [DisplayName("Fournisseur")]
        public int IdFournisseur { get; set; }
        
        [DisplayName("Nom du fournisseur")]
        public string Nom { get; set; }
        ICollection<Produit> Produits { get; set; }

        [DisplayName("Statut du fournisseur")]
        public int Statut { get; set; }
    }
}