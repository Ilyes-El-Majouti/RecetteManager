using System.Collections.Generic;

namespace RecetteManager.Models;
public class Etape
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty; // Ajout d'une valeur par défaut

    public int RecetteId { get; set; }
    public Recette Recette { get; set; } = null!; // Suppression du warning avec null-forgiving operator
}