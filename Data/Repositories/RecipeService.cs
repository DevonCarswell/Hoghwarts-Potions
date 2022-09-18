using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class RecipeService : IRecipeService
    {
        private readonly HogwartsContext _context;

        public RecipeService(HogwartsContext context)
        {
            _context = context;
        }
        public async Task AddRecipe(Recipe recipe)
        {
            await _context.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipe(long recipeId)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task DeleteRecipe(long recipeId)
        {
            var recipeToDelete = await GetRecipe(recipeId);
            if (recipeToDelete is not null)
            {
                _context.Recipes.Remove(recipeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
