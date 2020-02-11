namespace SiteTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Avis = new HashSet<Avi>();
            LigneCommandes = new HashSet<LigneCommande>();
        }

        

        [Key]
        public int IdProduit { get; set; }

        [StringLength(255)]
        public string Chemin { get; set; }

        [DataType(DataType.Currency)]
        public double PrixHt { get; set; }

        
        public int Stock { get; set; }

       
        public double Hauteur { get; set; }

        public double Largeur { get; set; }

        public int Capacité { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string NomProduit { get; set; }

       
        public int? IdFournisseur { get; set; }

        public int? IdCategorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneCommande> LigneCommandes { get; set; }
    }
}
