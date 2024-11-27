using Microsoft.EntityFrameworkCore;
using RecetteManager.Data;
using RecetteManager.Models;

namespace RecetteManager.Services
{
    public class RecetteService
    {
        private readonly ApplicationDbContext _dbContext;

        public RecetteService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Recette> GetAll()
        {
            return _dbContext.Recettes
                             .Include(r => r.Categorie)
                             .Include(r => r.Ingredients)
                             .Include(r => r.Etapes)
                             .Include(r => r.Commentaires)
                             .ToList();
        }

        public Recette? GetById(int id)
        {
            return _dbContext.Recettes
                             .Include(r => r.Categorie)
                             .Include(r => r.Ingredients)
                             .Include(r => r.Etapes)
                             .Include(r => r.Commentaires)
                             .FirstOrDefault(r => r.Id == id);
        }

        public void Add(Recette recette)
        {
            _dbContext.Recettes.Add(recette);
            _dbContext.SaveChanges();
        }

        public void Update(Recette recette)
        {
            _dbContext.Recettes.Update(recette);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var recette = _dbContext.Recettes.Find(id);
            if (recette != null)
            {
                _dbContext.Recettes.Remove(recette);
                _dbContext.SaveChanges();
            }
        }

        public List<Categorie> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}