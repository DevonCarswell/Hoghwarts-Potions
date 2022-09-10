using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class PotionService : IPotionService
    {
        private readonly HogwartsContext _context;
        private const int MAX_INGREDIENTS_FOR_POTIONS = 5;

        public PotionService(HogwartsContext context)
        {
            _context = context;
        }


        public Task AddPotion(Potion Potion, long studentId, HashSet<Ingredient> ingredients)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Potion> GetPotionById(long PotionId)
        {
            return await _context.Potions.FirstOrDefaultAsync(p => p.Id == PotionId);
        }

        public Task<List<Potion>> GetAllPotions()
        {
            return _context.Potions.ToListAsync();
        }

        public async Task DeletePotion(long id)
        {
            var potionToDelete = GetPotionById(id).Result;
            if (potionToDelete != null)
            {

                _context.Potions.Remove(potionToDelete);

            }

            await _context.SaveChangesAsync();
        }

        public Task<List<Potion>> GetPotionByStudentId(long studentId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddIngredientToPotion(long potionId, Ingredient ingredient)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Ingredient>> GetAllIngredientByPotionId(long potionId)
        {
            throw new System.NotImplementedException();
        }
    }
}
