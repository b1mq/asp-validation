using AspNetCore.Validation.StudentsDb.Interfaces;
using AspNetCore.Validation.StudentsDb.Repo;
using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Services
{
    public class StudentService:StudentRepo
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task AddStudent(Student student)
        {
           
            await _repository.AddStudent(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _repository.UpdateStudent(student);
        }

        public async Task DeleteStudent(int id)
        {
            
            var student = await _repository.GetStudentById(id);
            if (student != null)
            {
                await _repository.DeleteStudent(student);
            }
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _repository.StudentExists(id);
        }

        public bool IsEmailAllowed(string email)
        {
            if (email == "admin@ukr.net" || email == "admin@gmail.com")
            {
                return false;
            }
            return true;
        }
    }

}
