using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Interfaces
{
    public interface IStudent
    {
        Task AddStudent(Student Student);
        Task<Student> GetStudent(long StudentId);
        Task<List<Student>> GetAllStudents();
        void UpdateStudent(long id, Student Student);
        Task DeleteStudent(long id);
        Task<List<Student>> GetStudentsForRatOwners();
    }
}
