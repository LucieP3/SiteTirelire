using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(CommandeMetaData))]
    public partial class Commande { }
    public class CommandeMetaData
    {
        Client Client { get; set; }
        DateTime? DateCommande { get; set; }
        
        [DisplayName("Client")]
        public int IdClient { get; set; }
        
       [DisplayName("Commande")]
        public int IdCommande { get; set; }
        ICollection<LigneCommande> LigneCommandes { get; set; }
        
        [DisplayName("Mode de réglement du paiement")]
        public string ModeReglement { get; set; }
        
        [DisplayName("Prix toutes taxes")]
        [DataType(DataType.Currency)]
        public double PrixTTC { get; set; }
        
        [DisplayName("Statut de la commande")]
        public int StatutCommande { get; set; }
    }
}