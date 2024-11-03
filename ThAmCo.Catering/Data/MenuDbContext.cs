using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;


namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public CateringDbContext(DbContextOptions<CateringDbContext> options) : base(options) { }
        
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }

        public DbSet<FoodBooking> FoodBookings { get; set; }

        private string DbPath { get; set; } = string.Empty;

        // Constructor to set-up the database path & name for SQLite.
        public CateringDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Menu.db");
        }


        // confiquring SQLite as the database engine
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key for the join table MenuFoodItem(many to many relationship)
            builder.Entity<MenuFoodItem>()
                .HasKey(mf => new { mf.MenuId, mf.FoodItemId });

            


            //confiqure many to many relationship between menu and fooditem thru menufooditem
            builder.Entity<Menu>()
                .HasMany(m => m.MenuFoodItems)
                .WithOne(mf => mf.Menu)
                .HasForeignKey(mf => mf.MenuId)
                .OnDelete(DeleteBehavior.Restrict);
            // restrict deletion if related records exist.

            
            builder.Entity<FoodItem>()
                .HasMany(fi => fi.MenuFoodItems)
                .WithOne(mf => mf.FoodItem)
                .HasForeignKey(mf => mf.FoodItemId)
                .OnDelete(DeleteBehavior.Restrict);


            //Confiqure one to many relationship : a Menu can have many foodbookings
            builder.Entity<Menu>()
                .HasMany(m => m.FoodBookings)
                .WithOne(fb => fb.Menu)
                .HasForeignKey(fb => fb.MenuId)
                .OnDelete(DeleteBehavior.Restrict);


           


        }




    }
}
