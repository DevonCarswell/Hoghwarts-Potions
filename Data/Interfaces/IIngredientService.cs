using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Interfaces
{
    public interface IIngredientService
    {
        Task AddIngredient(Ingredient Ingredient);
        Task<Ingredient> GetIngredient(long IngredientId);
        Task<List<Ingredient>> GetAllIngredients();
        Task DeleteIngredient(long id);
    }
}
