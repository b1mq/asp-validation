using Microsoft.AspNetCore.Mvc.ModelBinding;
using Validation.Models;
namespace AspNetCore.Validation.StudentsDb.Interfaces
{
    public interface IValidationService
    {
        void ValidateStudent(Student student, ModelStateDictionary modelState);
    }
}
