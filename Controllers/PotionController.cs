using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("/potions")]
    public class PotionController
    {
        
        private readonly IIngredient _ingredientRepository;
        private readonly IPotion _potionRepository;
        private readonly IStudent _studentRepository;
        private readonly IRecipe _recipeRepository;

        public PotionController(IIngredient ingredientRepository, IPotion potionRepository, IStudent studentRepository, IRecipe recipeRepository)
        {
            _ingredientRepository = ingredientRepository;
            _potionRepository = potionRepository;
            _studentRepository = studentRepository;
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<List<Potion>> GetAllPotions()
        {
            return await _potionRepository.GetAllPotions();
        }
    }
}
