
namespace MVC_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connections= builder.Configuration.GetConnectionString("DefaultConnections")
                ?? throw new InvalidOperationException("No ConnectionString");

            // Add services to the container.
            builder.Services.AddDbContext<AppDbcontext>(options => options.UseSqlServer(connections));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategoryServices,CategoryServices>();
            builder.Services.AddScoped<IDevicesServices, DevicesServices>();
            builder.Services.AddScoped<IGameServices,GameServices>();

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
