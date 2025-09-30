using BusinessLogicLayer.Services.Classes;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Contexts;
using DataAccessLayer.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DI Container
            builder.Services.AddControllersWithViews();
            //Life Times [object] => AddScoped, AddSinglton, AddTranisent
            //builder.Services.AddScoped<ApplicationDbContext>();
            //AddDbContext => allow di dbcontext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer("ConnectionStrings");
                //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnectionString"]);
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnectionString"]);
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });
            builder.Services.AddScoped<IDepartmentReposatory, DepartmentReposatory>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            //ask u to create object from class IDepartmentReposatory => new instance from DepartmentReposatory
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();// middelware makes sure all requests secured in the deployment HTTPS
            }

            app.UseHttpsRedirection();

            //app.UseStaticFiles(); //used for wwwroot "should come before routing"
            app.UseRouting();

            //app.UseAuthentication();//login "so it should come first"
            app.UseAuthorization();//roles of users

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

/* NOTES:
 * ======
 * -> to rename all elements use ctrl + .
 * -> solution contain projects, class library container for common code
 * -> soft delete: اخفاء الداتا بدون ما امسحها من الداتا بيز
 * -> hard delete: مسح الداتا تماما من الداتا بيز 
 * 
 */