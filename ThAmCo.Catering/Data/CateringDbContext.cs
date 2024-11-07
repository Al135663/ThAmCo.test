using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Reflection.Emit;


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





            // Seed data for Menus
            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Italian Feast" },
                new Menu { MenuId = 2, MenuName = "Vegetarian Delight" },
                new Menu { MenuId = 3, MenuName = "BBQ Extravaganza" }
            );

            // Seed data for FoodItems
            builder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Spaghetti Carbonara", UnitPrice = 12.99m },
                new FoodItem { FoodItemId = 2, Description = "Caesar Salad", UnitPrice = 8.99m },
                new FoodItem { FoodItemId = 3, Description = "Grilled Veggie Skewers", UnitPrice = 10.50m },
                new FoodItem { FoodItemId = 4, Description = "BBQ Ribs", UnitPrice = 15.99m },
                new FoodItem { FoodItemId = 5, Description = "Garlic Bread", UnitPrice = 4.99m }
            );

            // Seed data for MenuFoodItems
            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 }, // Italian Feast -> Spaghetti Carbonara
                new MenuFoodItem { MenuId = 1, FoodItemId = 5 }, // Italian Feast -> Garlic Bread
                new MenuFoodItem { MenuId = 2, FoodItemId = 3 }, // Vegetarian Delight -> Grilled Veggie Skewers
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 }, // Vegetarian Delight -> Caesar Salad
                new MenuFoodItem { MenuId = 3, FoodItemId = 4 }  // BBQ Extravaganza -> BBQ Ribs
            );

            // Seed data for FoodBookings
            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookinId = 1, ClientReferenceId = 101, NumberOfGuests = 20, MenuId = 1 },
                new FoodBooking { FoodBookinId = 2, ClientReferenceId = 102, NumberOfGuests = 15, MenuId = 2 },
                new FoodBooking { FoodBookinId = 3, ClientReferenceId = 103, NumberOfGuests = 50, MenuId = 3 }
            );
        }




    }
}
