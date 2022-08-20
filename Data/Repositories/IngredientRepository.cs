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
    public class IngredientRepository : IIngredient
    {
        private readonly HogwartsContext _context;


        public Task AddIngredient(Ingredient Ingredient)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetIngredient(long IngredientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ingredient>> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Task DeleteIngredient(long id)
        {
            throw new NotImplementedException();
        }
    }
}
