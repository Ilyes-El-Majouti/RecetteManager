using System.Collections.Generic;

namespace RecetteManager.Models;

public class Categorie
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty; // Résout l'avertissement
    public List<Recette> Recettes { get; set; } = new List<Recette>();
}