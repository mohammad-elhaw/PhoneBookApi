using Microsoft.AspNetCore.Mvc;
using PhoneBook.Extenstions;
using PhoneBook.Presentation.ActionFilters;
using PhoneBook.Presentation.Controllers;

namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ConfigureCors();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<ValidationFilterAttribute>();
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(ContactsController).Assembly);

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var app = builder.Build();
            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors("AllowAngularApp");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
