using System.Collections.Generic;

namespace RecetteManager.Models;
public class Ingredient
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;

    public int RecetteId { get; set; }
    public Recette Recette { get; set; } = null!;
}