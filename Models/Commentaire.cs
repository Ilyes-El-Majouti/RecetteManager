using System.Collections.Generic;

namespace RecetteManager.Models;
public class Commentaire
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public int RecetteId { get; set; }
    public Recette Recette { get; set; } = null!;
}