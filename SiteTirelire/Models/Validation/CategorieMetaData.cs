using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(CategorieMetaData))]
    public partial class Categorie { }
    public class CategorieMetaData
    {
        
        [DisplayName("Description")]
        public string Description { get; set; }
        
        [DisplayName("Catégorie")]
        public int IdCategorie { get; set; }
        
        [DisplayName("Nom de la catégorie")]
        public string NomCategorie { get; set; }

        [DisplayName("Statut de la catégorie")]
        public int Statut { get; set; }
        ICollection<Produit> Produits { get; set; }
    }
}