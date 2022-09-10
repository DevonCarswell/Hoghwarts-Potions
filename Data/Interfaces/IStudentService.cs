using System.Collections.Generic;
using System.Threading.Tasks;
using HogwartsPotions.Models.Entities;

namespace HogwartsPotions.Interfaces
{
    public interface IStudentService
    {
        Task AddStudent(Student Student);
        Task<Student> GetStudent(long StudentId);
        Task<List<Student>> GetAllStudents();
        void UpdateStudentRoomId(HashSet<Student> students);
        Task DeleteStudent(long id);
    }
}
