using System;
using System.Collections.Generic;
using System.Linq;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;
using HogwartsPotions.Models.Enums;

namespace HogwartsPotions.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HogwartsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }


            //Students
            var harry = new Student() { Name = "Harry Potter", HouseType = HouseType.Gryffindor, PetType = PetType.Owl };
            var hermione = new Student()
            { Name = "Hermione Granger", HouseType = HouseType.Gryffindor, PetType = PetType.Cat };
            var melfoy = new Student() { Name = "Draco Malfoy", HouseType = HouseType.Slytherin, PetType = PetType.None };
           

            //Rooms
            var rooms = new HashSet<Room>()
            {
                new Room() {Capacity = 1, Residents = new HashSet<Student>() {harry}},
                new Room() {Capacity = 2, Residents = new HashSet<Student>() {hermione}},
                new Room() {Capacity = 1, Residents = new HashSet<Student>() {melfoy}}
            };



            //// Ingredients
            var specialOne = new Ingredient() { Name = "The special one" };
            var banana = new Ingredient() { Name = "Banana" };
            var newtSpleens = new Ingredient() { Name = "Newt spleens" };
            var orangeSnake = new Ingredient() { Name = "An orange snake" };
            var greenLeaf = new Ingredient() { Name = "A green leaf" };
            var pufferFishEyes = new Ingredient() { Name = "Puffer-fis eyes" };
            var driedNettles = new Ingredient() { Name = "Dried nettles" };
            var batSpleens = new Ingredient() { Name = "Bat spleens" };
            var mint = new Ingredient() { Name = "Mint" };
            var valerianSprigs = new Ingredient() { Name = "Valerian Sprigs" };
            var fireSeeds = new Ingredient() { Name = "Fire Seeds" };
            var powderedDragonHorn = new Ingredient() { Name = "Powdered dragon horn" };
            var lavender = new Ingredient() { Name = "Lavender" };
            var gomasBarbadensis = new Ingredient() { Name = "Gomas Barbadensis" };
            var asianDragonHair = new Ingredient() { Name = "Asian Dragon Hair" };
            var petroleumJelly = new Ingredient() { Name = "Petroleum Jelly" };
            var jobberknollFeathers = new Ingredient() { Name = "Jobberknoll feathers" };
            var stewedMandrake = new Ingredient() { Name = "Stewed Mandrake" };
            var powderedSage = new Ingredient() { Name = "Powdered Sage" };
            var galanthusNivalis = new Ingredient() { Name = "Galanthus Nivalis" };
            var alihotsy = new Ingredient() { Name = "Alihotsy" };
            var peppermint = new Ingredient() { Name = "Peppermint" };
            var eeleyes = new Ingredient() { Name = "Eel eyes" };
            //context.Ingredients.AddRange(new List<Ingredient>()
            //{
            //    specialOne,banana,newtSpleens, orangeSnake,greenLeaf,pufferFishEyes,driedNettles,batSpleens, mint,valerianSprigs,fireSeeds,powderedDragonHorn,lavender,gomasBarbadensis,asianDragonHair,petroleumJelly,jobberknollFeathers,stewedMandrake,powderedSage,galanthusNivalis,alihotsy,peppermint,eeleyes,
            //});


            //Recipes
            var fireBreathingPotionRecipe = new Recipe()
            {
                Name = "Fire-Breathing Potion",
                Ingredients = new HashSet<Ingredient>()
                {
                    mint, valerianSprigs, fireSeeds, powderedDragonHorn, lavender
                },
                Student = harry
            };


            var sleekeazysHairPotionRecipe = new Recipe()
            {
                Name = "Sleekeazy's Hair Potion",
                Ingredients = new HashSet<Ingredient>()
                {
                    gomasBarbadensis, asianDragonHair, petroleumJelly, specialOne, lavender
                },
                Student = melfoy
            };


            var memoryPotionRecipe = new Recipe()
            {
                Name = "Memory Potion",
                Ingredients = new HashSet<Ingredient>()
                {
                    jobberknollFeathers, stewedMandrake, powderedSage, galanthusNivalis, peppermint
                },
                Student = hermione
            };
            //context.Recipes.AddRange(new List<Recipe>()
            //{
            //    fireBreathingPotionRecipe, sleekeazysHairPotionRecipe, memoryPotionRecipe
            //});


            //Potions
            var fireBreathingPotion = new Potion()
            {
                BrewedBy = harry,
                BrewingStatus = BrewingStatus.Discovery,
                Name = "Fire-Breathing Potion",
                Recipe = fireBreathingPotionRecipe,
                Ingredients = new HashSet<Ingredient>()
                {
                    mint, valerianSprigs, fireSeeds, powderedDragonHorn, lavender
                }
            };


            var sleekeazysHairPotion = new Potion()
            {
                BrewedBy = melfoy,
                BrewingStatus = BrewingStatus.Discovery,
                Name = "Sleekeazy's Hair Potion",
                Recipe = sleekeazysHairPotionRecipe,
                Ingredients = new HashSet<Ingredient>()
                {
                    gomasBarbadensis, asianDragonHair, petroleumJelly, specialOne, lavender
                }
            };


            var memoryPotion = new Potion()
            {
                BrewedBy = hermione,
                BrewingStatus = BrewingStatus.Brew,
                Name = "Memory Potion",
                Recipe = memoryPotionRecipe,
                // Need peppermint to change BrewingStatus to BrewingStatus.Discovery
                Ingredients = new HashSet<Ingredient>()
                {
                    jobberknollFeathers, stewedMandrake, powderedSage, galanthusNivalis,
                },
            };


            context.Potions.AddRange(new List<Potion>(){fireBreathingPotion,sleekeazysHairPotion,memoryPotion});


            // context.Students.AddRange(new List<Student>() { harry, hermione, melfoy });

            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }

            context.SaveChanges();
        }
    }
}
