using GoEdu.Data;
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
