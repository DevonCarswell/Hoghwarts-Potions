using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsPotions.Interfaces;
using HogwartsPotions.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HogwartsPotions.Data.Repositories
{
    public class StudentRepository : IStudent
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

        public void UpdateStudentRoomId(HashSet<Student> students)
        {
            
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    student.Room = null;
                    _context.Students.Update(student);
                    _context.SaveChanges();
                }

            }
            

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