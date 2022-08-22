using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class PotionRepository : IPotion
    {
        private readonly HogwartsContext _context;

        public PotionRepository(HogwartsContext context)
        {
            _context = context;
        }


        public Task AddPotion(Potion Potion, long studentId, HashSet<Ingredient> ingredients)
        {
            throw new System.NotImplementedException();
        }

        public Task<Potion> GetPotion(long PotionId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Potion>> GetAllPotions()
        {
            return _context.Potions.Include(p => p.Ingredients).ToListAsync();
        }

        public Task DeletePotion(long id)
        {
            throw new System.NotImplementedException();
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
