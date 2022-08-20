using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Data.Repositories
{
    public class RecipeRepository : IRecipe
    {
        private readonly HogwartsContext _context;

        public RecipeRepository(HogwartsContext context)
        {
            _context = context;
        }
        public Task AddRecipe(Recipe Recipe)
        {
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipe(long RecipeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Recipe>> GetAllRecipes()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRecipe(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
