using AspNetCore.Validation.StudentsDb.Interfaces;
using Validation.DbContexts;
using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly MyDbContext _context;

        public StudentRepo(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByIdc(int id)
        {
            return await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(e => e.Id == id);
        }
    }
}
