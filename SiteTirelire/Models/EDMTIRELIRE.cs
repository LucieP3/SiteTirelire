namespace SiteTirelire.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDMTIRELIRE : DbContext
    {
        public EDMTIRELIRE()
            : base("name=EDMTIRELIRE")
        {
        }

        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }
        public virtual DbSet<Fournisseur> Fournisseur { get; set; }
        public virtual DbSet<LigneCommande> LigneCommande { get; set; }
        public virtual DbSet<Produit> Produit { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.Categorie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Avis)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.LigneCommandes)
                .WithRequired(e => e.Commande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fournisseur>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.Fournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Chemin)
                .IsUnicode(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Avis)
                .WithRequired(e => e.Produit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.LigneCommandes)
                .WithRequired(e => e.Produit)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Role>()
            .Property(e => e.RoleAttribue)
           .IsFixedLength();
        }
    }
}
