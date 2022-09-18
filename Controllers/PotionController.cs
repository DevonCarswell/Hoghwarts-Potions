using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsPotions.Controllers
{
    [ApiController, Route("[Controller]")]
    public class PotionController
    {
        
        private readonly IIngredientService _ingredientRepository;
        private readonly IPotionService _potionRepository;
        private readonly IStudentService _studentRepository;
        private readonly IRecipeService _recipeRepository;

        public PotionController(IIngredientService ingredientRepository, IPotionService potionRepository, IStudentService studentRepository, IRecipeService recipeRepository)
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

        [HttpPost]
        public async Task<Potion> BrewPotion([FromBody] Potion potion)
        {
           return await _potionRepository.AddPotion(potion);
        }

        
    }
}
