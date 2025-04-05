using GoEdu.Data;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
=======
using GoEdu.Repositories;
>>>>>>> origin/main
using Microsoft.EntityFrameworkCore;

namespace GoEdu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // add context
            builder.Services.AddDbContext<GoEduContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            //register unit of work 
            builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
<<<<<<< HEAD

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

=======
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
>>>>>>> origin/main


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
