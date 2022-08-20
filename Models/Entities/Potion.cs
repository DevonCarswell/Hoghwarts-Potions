using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.Models.Entities
{
    public class Potion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }
        public BrewingStatus BrewingStatus { get; set; }
        public HashSet<Ingredient> Ingredients { get; set; }

        public long StudentId { get; set; }
        public Student BrewedBy { get; set; }
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
