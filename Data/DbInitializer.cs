using System;
using System.Linq;
using HogwartsPotions.Models;
using HogwartsPotions.Models.Entities;

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

        }
    }
}
