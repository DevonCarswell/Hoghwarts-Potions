using HogwartsPotions.Interfaces;

namespace HogwartsPotions.Controllers
{
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
    }
}
