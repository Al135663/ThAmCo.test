using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Reflection.Emit;


namespace ThAmCo.Catering.Data
{

    // Represents the database context for the catering system, including entities like FoodItems, Menus, MenuFoodItems, and FoodBookings.
    // This context manages connections to the SQLite database and configures relationships among entities.

    public class CateringDbContext : DbContext
    {
        // Constructor for dependency injection, allowing configuration to be passed in.
       // public CateringDbContext(DbContextOptions<CateringDbContext> options) : base(options) { }


        // DbSet for FoodItem entity, representing a table of food items in the database.
        public DbSet<FoodItem> FoodItems { get; set; }


        // DbSet for Menu entity, representing a table of menus in the database.
        public DbSet<Menu> Menus { get; set; }


        // DbSet for MenuFoodItem entity, representing a join table linking menus and food items.
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }


        // DbSet for FoodBooking entity, representing a table of food bookings associated with events.
        public DbSet<FoodBooking> FoodBookings { get; set; }


        // Property to hold the database file path for SQLite.
        private string DbPath { get; set; } = string.Empty;

        // Default Constructor to set-up the database path & name for SQLite.
        public CateringDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Menu.db");
        }


        // Configures SQLite as the database engine using the database path specified in DbPath.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }


        // Configures entity relationships and keys using the Fluent API.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Defines a composite primary key for the MenuFoodItem entity (many-to-many relationship between Menu and FoodItem).
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
                .OnDelete(DeleteBehavior.Restrict);  // Restricts deletion if related records exist.


            //Confiqure one to many relationship : a Menu can have many foodbookings
            builder.Entity<Menu>()
                .HasMany(m => m.FoodBookings)
                .WithOne(fb => fb.Menu)
                .HasForeignKey(fb => fb.MenuId)
                .OnDelete(DeleteBehavior.Restrict); // Restricts deletion if related records exist in FoodBookings.





            // Seed data for Menus
            builder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Italian Feast" },
                new Menu { MenuId = 2, MenuName = "Vegetarian Delight" },
                new Menu { MenuId = 3, MenuName = "BBQ Extravaganza" },
                new Menu { MenuId = 4, MenuName = "Asian Fusion" },
                new Menu { MenuId = 5, MenuName = "Classic American" }
            );

            // Seed data for FoodItems
            builder.Entity<FoodItem>().HasData(
    new FoodItem { FoodItemId = 1, Description = "Spaghetti Carbonara", UnitPrice = 12.99m },
    new FoodItem { FoodItemId = 2, Description = "Caesar Salad", UnitPrice = 8.99m },
    new FoodItem { FoodItemId = 3, Description = "Grilled Veggie Skewers", UnitPrice = 10.50m },
    new FoodItem { FoodItemId = 4, Description = "BBQ Ribs", UnitPrice = 15.99m },
    new FoodItem { FoodItemId = 5, Description = "Garlic Bread", UnitPrice = 4.99m },
    new FoodItem { FoodItemId = 6, Description = "Sushi Platter", UnitPrice = 18.99m },
    new FoodItem { FoodItemId = 7, Description = "Miso Soup", UnitPrice = 3.99m },
    new FoodItem { FoodItemId = 8, Description = "Bacon Cheeseburger", UnitPrice = 12.49m },
    new FoodItem { FoodItemId = 9, Description = "Fries", UnitPrice = 2.99m },
    new FoodItem { FoodItemId = 10, Description = "Steak and Eggs", UnitPrice = 17.99m }
);

            // Seed data for MenuFoodItems
            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 }, // Italian Feast -> Spaghetti Carbonara
                new MenuFoodItem { MenuId = 1, FoodItemId = 5 }, // Italian Feast -> Garlic Bread
                new MenuFoodItem { MenuId = 2, FoodItemId = 3 }, // Vegetarian Delight -> Grilled Veggie Skewers
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 }, // Vegetarian Delight -> Caesar Salad
                new MenuFoodItem { MenuId = 3, FoodItemId = 4 }, // BBQ Extravaganza -> BBQ Ribs
                new MenuFoodItem { MenuId = 4, FoodItemId = 6 }, // Asian Fusion -> Sushi Platter
                new MenuFoodItem { MenuId = 4, FoodItemId = 7 }, // Asian Fusion -> Miso Soup
                new MenuFoodItem { MenuId = 5, FoodItemId = 8 }, // Classic American -> Bacon Cheeseburger
                new MenuFoodItem { MenuId = 5, FoodItemId = 9 }, // Classic American -> Fries
                new MenuFoodItem { MenuId = 5, FoodItemId = 10 } // Classic American -> Steak and Eggs
);

            // Seed data for FoodBookings
            builder.Entity<FoodBooking>().HasData(
               new FoodBooking { FoodBookingId = 1, ClientReferenceId = 101, NumberOfGuests = 20, MenuId = 1 },
               new FoodBooking { FoodBookingId = 2, ClientReferenceId = 102, NumberOfGuests = 15, MenuId = 2 },
               new FoodBooking { FoodBookingId = 3, ClientReferenceId = 103, NumberOfGuests = 50, MenuId = 3 },
               new FoodBooking { FoodBookingId = 4, ClientReferenceId = 104, NumberOfGuests = 30, MenuId = 4 },
               new FoodBooking { FoodBookingId = 5, ClientReferenceId = 105, NumberOfGuests = 25, MenuId = 5 },
               new FoodBooking { FoodBookingId = 6, ClientReferenceId = 106, NumberOfGuests = 10, MenuId = 1 },
               new FoodBooking { FoodBookingId = 7, ClientReferenceId = 107, NumberOfGuests = 40, MenuId = 2 }
);
        }




    }
}
