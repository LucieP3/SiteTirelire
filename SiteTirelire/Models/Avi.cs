namespace SiteTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avi
    {
        [Key]
        public int IdAvis { get; set; }

        public int IdProduit { get; set; }

        public int IdClient { get; set; }

        [Required]
        public string Commentaire { get; set; }

        [Required]
        
        public int Etape { get; set; }

      
        public DateTime Date { get; set; }

        public double Notation { get; set; }

        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
