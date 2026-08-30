using AspNetCore.Validation.StudentsDb.Interfaces;

namespace AspNetCore.Validation.StudentsDb.Services.Extensions
{
    public static class ValidationExtension
    {
        public static IServiceCollection AddMyValid(this IServiceCollection services)
        {
            services.AddScoped<IValidationService, ValidationService>();
            return services;
        }
    }
}
