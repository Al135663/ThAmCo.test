using System.Collections.Generic; // provides access to ICollection<T>.Menu class has a property called MenuFoodItems that represents a collection of MenuFoodItem objects. 
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{// this class represent menu with multiple fooditems. with Name and optional description
    public class Menu
    {
        [Key]// unique identifier
        public int MenuId { get; set; }
       
        public required string MenuName { get; set; }// The name of the menu, required for every instance of menu.


        // Navigation property representing bookings associated with this menu.
        // Nullable to allow for cases where no bookings have been made.
        public List<FoodBooking>? FoodBookings { get; set; }


        // Navigation property representing the collection of food items associated with this menu.
        // Each MenuFoodItem links a specific food item to this menu.
        // Nullable to allow for cases where no food items are initially linked.
        public List<MenuFoodItem>? MenuFoodItems { get; set; }
    }
}
