namespace SiteTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LigneCommande")]
    public partial class LigneCommande 
    {
        [Key]
        public int IdLigneCommande { get; set; }

        public int? IdProduit { get; set; }

        public int Quantité { get; set; }

        public int IdCommande { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Produit Produit { get; set; }

        [StringLength(50)]
        public string NomProduit { get; set; }

        [DataType(DataType.Currency)]
        public double PrixUnitaire { get; set; }
    }
}
