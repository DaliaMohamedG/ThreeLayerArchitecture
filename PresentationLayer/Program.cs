namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
 * 
 * 
 * 
 * 
 * 
 * 
 */