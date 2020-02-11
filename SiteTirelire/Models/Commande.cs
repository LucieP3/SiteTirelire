namespace SiteTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commande")]
    public partial class Commande 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            LigneCommandes = new HashSet<LigneCommande>();
        }

        [Key]
        public int IdCommande { get; set; }

        public int? IdClient { get; set; }

    
        public DateTime? DateCommande { get; set; }

        
        public int StatutCommande { get; set; }

        [DataType(DataType.Currency)]
        public double PrixTTC { get; set; }

      
        public string ModeReglement { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }
    }
}
