using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Interfaces
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Student student);
        Task<bool> StudentExists(int id);
    }
}
