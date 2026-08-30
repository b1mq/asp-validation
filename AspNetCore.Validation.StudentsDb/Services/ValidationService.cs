using AspNetCore.Validation.StudentsDb.Interfaces;
using Validation.Models;

namespace AspNetCore.Validation.StudentsDb.Services
{
    public interface ValidationService:IValidationService
    {
        public void ValidateStudent(Student student, ModelStateDictionary modelState)
        {
            if (student.Surname == "admin")
                modelState.AddModelError("Surname", "admin - заборонене прізвище");

            if (student.Name == student.Email)
                modelState.AddModelError("", "ім’я та електронна адреса не повинні збігатися");
        }
    }
}
