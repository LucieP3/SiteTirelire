using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(AviMetaData))]
    public partial class Avi { }
    public class AviMetaData
    {
        Client Client { get; set; }
        
        [DisplayName("Ceci est un avis")]
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }
        
        [DisplayName("Étapes")]
        public int Etape { get; set; }
        
        [DisplayName("Avis")]
        public int IdAvis { get; set; }
        
        [DisplayName("Client")]
        public int IdClient { get; set; }
        
        [DisplayName("Produit concerné")]
        public int IdProduit { get; set; }
        
        [DisplayName("Ceci est une note")]
        public double Notation { get; set; }
        Produit Produit { get; set; }
    }
}