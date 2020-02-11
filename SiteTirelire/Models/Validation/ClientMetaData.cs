using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteTirelire.Models
{
    [MetadataType(typeof(ClientMetaData))]
    public partial class Client { }
    public class ClientMetaData
    {
        
        [DisplayName("Adresse du client")]
        public string Adresse { get; set; }
        ICollection<Avi> Avis { get; set; }
        ICollection<Commande> Commandes { get; set; }
        
        [DisplayName("Email du client")]
        public string Email { get; set; }
        
        [DisplayName("Client")]
        public int IdClient { get; set; }
        
        [DisplayName("Nom du client")]
        public string Nom { get; set; }
        
        [DisplayName("Prénom du client")]
        public string Prénom { get; set; }

    }
}