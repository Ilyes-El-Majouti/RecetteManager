using Microsoft.EntityFrameworkCore;
using RecetteManager.Data;
using RecetteManager.Models;
using RecetteManager.Services;
using System;
using System.Collections.Generic;

namespace RecetteManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurer le contexte de base de données et le service Recette
            var dbContext = new ApplicationDbContext();
            var recetteService = new RecetteService(dbContext);

            // Créer la base de données si elle n'existe pas encore
            dbContext.Database.EnsureCreated();

            // Afficher le menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Gestion des Recettes =====");
                Console.WriteLine("1. Ajouter une recette");
                Console.WriteLine("2. Afficher toutes les recettes");
                Console.WriteLine("3. Modifier une recette");
                Console.WriteLine("4. Supprimer une recette");
                Console.WriteLine("5. Quitter");
                Console.WriteLine("===============================");
                Console.Write("Choisissez une option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AjouterRecette(recetteService);
                        break;

                    case "2":
                        AfficherRecettes(recetteService);
                        break;

                    case "3":
                        ModifierRecette(recetteService);
                        break;

                    case "4":
                        SupprimerRecette(recetteService);
                        break;

                    case "5":
                        Console.WriteLine("Merci d'avoir utilisé l'application de gestion des recettes !");
                        return;

                    default:
                        Console.WriteLine("Option invalide. Appuyez sur une touche pour recommencer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Ajouter une recette
        private static void AjouterRecette(RecetteService recetteService)
        {
            Console.Write("Entrez le nom de la recette: ");
            var nom = Console.ReadLine();

            Console.Write("Entrez le temps de préparation (en minutes): ");
            var tempsPrep = int.Parse(Console.ReadLine());

            Console.Write("Entrez le temps de cuisson (en minutes): ");
            var tempsCuisson = int.Parse(Console.ReadLine());

            Console.Write("Entrez la difficulté de la recette (Facile, Moyen, Difficile): ");
            var difficulte = Console.ReadLine();  // Difficulté maintenant en string

            Console.WriteLine("Choisissez une catégorie:");
            var categories = recetteService.GetAllCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Nom}");
            }
            var categorieChoisie = int.Parse(Console.ReadLine()) - 1;

            var recette = new Recette
            {
                Nom = nom,
                TempsPrep = tempsPrep,
                TempsCuisson = tempsCuisson,
                Difficulte = difficulte,  // Directement assigné en tant que chaîne
                CategorieId = categories[categorieChoisie].Id
            };

            recetteService.Add(recette);
            Console.WriteLine("Recette ajoutée avec succès !");
            Console.ReadKey();
        }

        // Lire un entier en gérant les erreurs de saisie
        private static int LireEntier()
        {
            int valeur;
            while (!int.TryParse(Console.ReadLine(), out valeur))
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
            }
            return valeur;
        }

        // Modifier une recette
        private static void ModifierRecette(RecetteService recetteService)
        {
            Console.Write("Entrez l'ID de la recette à modifier: ");
            var id = int.Parse(Console.ReadLine());

            var recette = recetteService.GetById(id);
            if (recette == null)
            {
                Console.WriteLine("Recette introuvable.");
            }
            else
            {
                Console.Write("Entrez le nouveau nom de la recette: ");
                recette.Nom = Console.ReadLine();

                Console.Write("Entrez le nouveau temps de préparation (en minutes): ");
                recette.TempsPrep = int.Parse(Console.ReadLine());

                Console.Write("Entrez le nouveau temps de cuisson (en minutes): ");
                recette.TempsCuisson = int.Parse(Console.ReadLine());

                Console.Write("Entrez la nouvelle difficulté de la recette (Facile, Moyen, Difficile): ");
                recette.Difficulte = Console.ReadLine();  // Difficulté modifiée ici en string

                Console.WriteLine("Choisissez une nouvelle catégorie:");
                var categories = recetteService.GetAllCategories();
                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i].Nom}");
                }
                var categorieChoisie = int.Parse(Console.ReadLine()) - 1;
                recette.CategorieId = categories[categorieChoisie].Id;

                recetteService.Update(recette);
                Console.WriteLine("Recette modifiée avec succès !");
            }
            Console.ReadKey();
        }

        // Supprimer une recette
        private static void SupprimerRecette(RecetteService recetteService)
        {
            Console.Write("Entrez l'ID de la recette à supprimer: ");
            var id = LireEntier();

            var recette = recetteService.GetById(id);
            if (recette == null)
            {
                Console.WriteLine("Recette introuvable.");
            }
            else
            {
                recetteService.Delete(id);
                Console.WriteLine("Recette supprimée avec succès !");
            }
            Console.ReadKey();
        }

        // Afficher toutes les recettes
        private static void AfficherRecettes(RecetteService recetteService)
        {
            Console.Clear();
            var recettes = recetteService.GetAll();
            if (recettes.Count == 0)
            {
                Console.WriteLine("Aucune recette trouvée.");
            }
            else
            {
                foreach (var recette in recettes)
                {
                    Console.WriteLine($"Id: {recette.Id}");
                    Console.WriteLine($"Nom: {recette.Nom}");
                    Console.WriteLine($"Préparation: {recette.TempsPrep} minutes");
                    Console.WriteLine($"Cuisson: {recette.TempsCuisson} minutes");
                    // Conversion explicite de Difficulte en chaîne ici avec ToString()
                    Console.WriteLine($"Difficulte: {recette.Difficulte.ToString()}");
                    Console.WriteLine($"Catégorie: {recette.Categorie?.Nom}");
                    Console.WriteLine("-----------------------------");
                }
            }
            Console.WriteLine("Esc. Retour");
            Console.ReadKey();
        }
    }
}