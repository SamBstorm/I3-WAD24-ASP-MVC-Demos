namespace Demo_ASP_01
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "privacyRoute",
                pattern: "privacy",
                defaults: new { Controller = "Home", Action = "Privacy"}
                );

            app.MapControllerRoute(
                name: "privacyRouteFR",
                pattern: "conditions",
                defaults: new { Controller = "Home", Action = "Privacy" }
                );

            app.MapControllerRoute(
                name: "additionRoute",
                pattern: "Home/Addition/{nb1}/{nb2}",
                defaults: new { Controller = "Home", Action = "Addition" }
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
