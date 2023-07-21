using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using kelly.Areas.Identity.Data;

public class Program { 
    
   public static async Task Main(string[] args) 
   {
    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("kellyDbContextConnection") ?? throw new InvalidOperationException("Connection string 'kellyDbContextConnection' not found.");

    builder.Services.AddDbContext<kellyDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddDefaultIdentity<kellyUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<kellyDbContext>();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
         // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();;

        app.UseAuthorization();
        app.MapRazorPages();

        app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");


    using(var scope = app.Services.CreateScope())
    {
           var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

           var roles = new[] { "Admin", "Manager", "Customer" };

          foreach (var role in roles)
          {
              if (!await roleManager.RoleExistsAsync(role))
              await roleManager.CreateAsync(new IdentityRole(role));
          }
    }

        using (var scope = app.Services.CreateScope())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<kellyUser>>();

            string email = "admin@admin.com";
            string password = "Admin!1234";
            

           if(await userManager.FindByEmailAsync(email) == null)
            {
                var user = new kellyUser();
                user.Email = email;
                user.UserName = email;
                user.FirstName = email; 
                user.LastName = email;

                await userManager.CreateAsync(user, password);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        app.Run();

   }

}








