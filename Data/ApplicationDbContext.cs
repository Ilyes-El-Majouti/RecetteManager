using Microsoft.EntityFrameworkCore;
using RecetteManager.Models;

namespace RecetteManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recette> Recettes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Etape> Etapes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utiliser SQLite comme base de données
            optionsBuilder.UseSqlite("Data Source=recettes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurer une relation Recette -> Categorie (1 à plusieurs)
            modelBuilder.Entity<Recette>()
                        .HasOne(r => r.Categorie)
                        .WithMany()
                        .HasForeignKey(r => r.CategorieId);

            // Ajouter des catégories par défaut
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Nom = "Aucune" },
                new Categorie { Id = 2, Nom = "Dessert" },
                new Categorie { Id = 3, Nom = "Plat Principal" },
                new Categorie { Id = 4, Nom = "Entrée" }
            );
        }
    }
}