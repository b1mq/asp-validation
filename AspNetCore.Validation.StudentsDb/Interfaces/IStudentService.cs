using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
        Task<bool> StudentExists(int id);
        bool IsEmailAllowed(string email);
    }
}
