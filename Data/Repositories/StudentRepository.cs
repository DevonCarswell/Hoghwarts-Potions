using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly HogwartsContext _context;

        public StudentRepository(HogwartsContext context)
        {
            _context = context;
        }
        public async Task AddStudent(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

        }

        public Task<Student> GetStudent(long StudentId)
        {
            return _context.Students.FirstOrDefaultAsync(r => r.ID == StudentId);
        }

        public Task<List<Student>> GetAllStudents()
        {
            return _context.Students.ToListAsync();
        }

        public void UpdateStudent(long id, Student Student)
        {
            var StudentToUpdate = GetStudent(id).Result;
            if (StudentToUpdate != null)
            {
                Student.ID = StudentToUpdate.ID;
                _context.Students.Update(Student);

            }
            _context.SaveChangesAsync();

        }

        public async Task DeleteStudent(long id)
        {
            var StudentToDelete = _context.Students.FirstOrDefaultAsync(r => r.ID == id).Result;
            if (StudentToDelete != null)
            {
                _context.Students.Remove(StudentToDelete);

            }

            await _context.SaveChangesAsync();
        }

  


    }
}