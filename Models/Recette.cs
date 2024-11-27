using System.Collections.Generic;

namespace RecetteManager.Models;

public class Recette
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;

    public int TempsPrep { get; set; }
    public int TempsCuisson { get; set; }
    public string Difficulte { get; set; } = string.Empty;

    public int? CategorieId { get; set; }
    public Categorie? Categorie { get; set; } // Nullable si aucune catégorie

    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<Etape> Etapes { get; set; } = new List<Etape>();
    public List<Commentaire> Commentaires { get; set; } = new List<Commentaire>();
}