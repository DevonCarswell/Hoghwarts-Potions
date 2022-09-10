using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Interfaces
{
    public interface IRecipeService
    {
        Task AddRecipe(Recipe Recipe);
        Task<Recipe> GetRecipe(long RecipeId);
        Task<List<Recipe>> GetAllRecipes();
        Task DeleteRecipe(long id);
    }
}
