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

            var harry = new Student() {Name = "Harry Potter", HouseType = HouseType.Gryffindor, PetType = PetType.Owl};
            var hermione = new Student() {Name = "Hermione Granger", HouseType = HouseType.Gryffindor, PetType = PetType.Cat};
            var melfoy = new Student() {Name = "Draco Malfoy", HouseType = HouseType.Slytherin, PetType = PetType.None};

            var rooms = new HashSet<Room>()
            {
                new Room() {Capacity = 1, Residents = new HashSet<Student>() {harry}},
                new Room() {Capacity = 2, Residents = new HashSet<Student>() {hermione}},
                new Room(){Capacity = 1, Residents = new HashSet<Student>() {melfoy}}
            };
            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges();
        }
    }
}
