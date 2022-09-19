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
            var newPotion = new Potion() {Name = potion.Name, Student = potion.Student };
            foreach (var ingredient in potion.Ingredients)
            {
                if (_context.Ingredients.All(i => i.Name != ingredient.Name))
                {
                    await _context.Ingredients.AddAsync(ingredient);
                    newPotion.Ingredients.Add(ingredient);
                }
                else
                {
                    var existIngredient =
                        await _context.Ingredients.FirstOrDefaultAsync(i => i.Name == ingredient.Name);
                    newPotion.Ingredients.Add(existIngredient);
                }

            }

            if (newPotion.Ingredients.Count == MAX_INGREDIENTS_FOR_POTIONS)
            {
                if (await CheckPotionReplicaOrDiscovery(newPotion.Ingredients))
                {
                    newPotion.BrewingStatus = BrewingStatus.Replica;
                    return newPotion;
                }
                var recipeCounter = _context.Recipes.Count(r => r.Student.ID == potion.Student.ID) + 1;
                newPotion.BrewingStatus = BrewingStatus.Discovery;
                var newRecipe = new Recipe()
                {
                    Name = $"{newPotion.Student.Name}'s discovery #{recipeCounter}", Ingredients = newPotion.Ingredients
                };
                newPotion.Recipe = newRecipe;
            }

            await _context.Potions.AddAsync(newPotion);
            await _context.SaveChangesAsync();
            return newPotion;
        }

        public async Task<Potion> GetPotionById(long potionId)
        {
            return await _context.Potions.FirstOrDefaultAsync(p => p.Id == potionId);
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

    
        public async Task<List<Potion>> GetPotionsByStudentId(long studentId)
        {
            var potions = await _context.Potions.Where(p => p.Student.ID == studentId).ToListAsync();
            return potions;
        }

        public async Task AddIngredientToPotion(long potionId, Ingredient ingredient)
        {
            var potion = await GetPotionById(potionId);
            if (potion is not null && potion.Ingredients.Count < MAX_INGREDIENTS_FOR_POTIONS)
            {
                if (potion.Ingredients.Any(i => i.Name == ingredient.Name))
                {
                    return;
                }

                potion.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();
                if (potion.Ingredients.Count == MAX_INGREDIENTS_FOR_POTIONS)
                {
                    if (await CheckPotionReplicaOrDiscovery(potion.Ingredients))
                    {
                        potion.BrewingStatus = BrewingStatus.Replica;
                    }
                    else
                    {
                        potion.BrewingStatus = BrewingStatus.Discovery;
                    }
                }
            }

            

        }

        private async Task<bool> CheckPotionReplicaOrDiscovery(HashSet<Ingredient> newIngredients)
        {
            var recipes = await _context.Recipes.ToListAsync();
            foreach (var recipe in recipes)
            {
                if (newIngredients.SequenceEqual(recipe.Ingredients))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
