using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Interfaces
{
    public interface IPotionService
    {
        Task AddPotion(Potion Potion, long studentId, HashSet<Ingredient> ingredients);
        Task<Potion> GetPotionById(long PotionId);
        Task<List<Potion>> GetAllPotions();
        Task DeletePotion(long id);
        Task<List<Potion>> GetPotionByStudentId(long studentId);
        Task AddIngredientToPotion(long potionId,Ingredient ingredient);
        Task<List<Ingredient>> GetAllIngredientByPotionId(long potionId);
    }
}
