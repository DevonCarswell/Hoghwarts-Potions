using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
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


        public async Task<Potion> AddPotion(Potion potion)
        {
            var potions = await GetAllPotions();
            if (potion.Ingredients.Count == MAX_INGREDIENTS_FOR_POTIONS)
            {
                foreach (var mixture in potions)
                {
                    if (CheckPotionReplicaOrDiscovery(potion.Ingredients, mixture.Recipe.Ingredients))
                    {
                        potion.BrewingStatus = BrewingStatus.Replica;
                        return potion;
                    }
                }
            }
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

        public async Task<List<Potion>> GetPotionByStudentId(long studentId)
        {
            var potions = await _context.Potions.Where(p => p.Student.ID == studentId).ToListAsync();
            return potions;
        }

        public Task AddIngredientToPotion(long potionId, Ingredient ingredient)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Ingredient>> GetAllIngredientByPotionId(long potionId)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckPotionReplicaOrDiscovery(HashSet<Ingredient> newIngredients, HashSet<Ingredient> ingredients)
        {
            return newIngredients.SequenceEqual(ingredients);
        }

    }
}
