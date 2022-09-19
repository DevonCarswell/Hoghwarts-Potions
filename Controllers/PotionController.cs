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

        [HttpGet("{studentId}")]
        public async Task<List<Potion>> GetAllPotionsByStudent(long studentId)
        {
            var potions = await _potionRepository.GetPotionsByStudentId(studentId);
            return potions;
        }


        [HttpPost("brew/{studentId}")]
        public async Task BrewPotion(long studentId)
        {
            var student = await _studentRepository.GetStudent(studentId);

            if (student is not null)
            {
                var poti = new Potion() {Student = student};
                await _potionRepository.AddPotion(poti);
            }

        }


        [HttpPut("{potionId}/add")]
        public async Task<Potion> AddIngredientToPotion(long potionId, [FromBody] Ingredient ingredient)
        {
            var potion = await _potionRepository.GetPotionById(potionId);
            if (potion is not null)
            {
                var ingredients = await _ingredientRepository.GetAllIngredients();
                foreach (var element in ingredients)
                {
                    if (element.Name == ingredient.Name)
                    {
                        await _potionRepository.AddIngredientToPotion(potionId, ingredient);
                    }
                    else
                    {
                        await _ingredientRepository.AddIngredient(ingredient);
                        await _potionRepository.AddIngredientToPotion(potionId, ingredient);
                    }
                }
            }

            return potion;
            
        }

        [HttpGet("{potionId}/help")]
        public async Task<List<Recipe>> GetAllRecipesWithPotionIngredients(long potionId)
        {
            return await _recipeRepository.GetRecipesByPotionId(potionId);
        }
    }
}
