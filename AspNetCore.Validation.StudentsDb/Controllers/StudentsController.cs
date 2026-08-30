using AspNetCore.Validation.StudentsDb.Interfaces;
using AspNetCore.Validation.StudentsDb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Validation.DbContexts;
using Validation.Models;

namespace Validation.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IValidationService _validationService;

        public StudentsController(IStudentService studentService, IValidationService validationService)
        {
            _studentService = studentService;
            _validationService = validationService;
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email)
        {
            bool isAllowed = _studentService.IsEmailAllowed(email);
            return Json(isAllowed);
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudents();
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentById(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost] // метод виконується тільки при POST-запиті (наприклад, відправка форми)
        [ValidateAntiForgeryToken] // перевіряє токен захисту від CSRF-атак, обов'язково
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Age,GPA,Email")] Student student) // приймає об’єкт студента з прив’язкою лише вказаних полів
        {
            _validationService.ValidateStudent(student);
            if (ModelState.isValid)
            {
                await _studentService.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student); 
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentById(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Age,GPA,Email")] Student student)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(m => m.Id == id);
            if (student != null) _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}