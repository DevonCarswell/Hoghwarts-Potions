using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class IngredientService : IIngredientService
    {
        private readonly HogwartsContext _context;

        public IngredientService(HogwartsContext context)
        {
            _context = context;
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task<Ingredient> GetIngredient(long ingredientId)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == ingredientId);
        }

        public async Task<List<Ingredient>> GetAllIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task DeleteIngredient(long id)
        {
            var ingredientToDelete = await GetIngredient(id);
            if (ingredientToDelete is not null)
            {
                _context.Ingredients.Remove(ingredientToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
