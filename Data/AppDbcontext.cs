
using MVC_CRUD.Models;

namespace MVC_CRUD.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GameDevice>().HasKey(key => new { key.DeviceId, key.GameId });
            builder.Entity<Category>().HasData(new Category[]{
                new Category{ ID=1, Name="Sports" },
                new Category{ ID=2, Name="Action" },
                new Category{ ID=3, Name="Adventure" },
                new Category{ ID=4, Name="Racing" },
                new Category{ ID=5, Name="Fighting" },
                new Category{ ID=6, Name="Film" }
            });
            builder.Entity<Device>().HasData(new Device[] {
             new Device{ ID=1, Name="Playstation", Icon="bi bi-playstation"},
             new Device{ ID=2, Name="xbox", Icon="bi bi-xbox"},
             new Device{ ID=3, Name="PC", Icon="bi bi-pc-display"},

            });
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }

    }
}
