using System.Collections.Generic; // provides access to ICollection<T>.Menu class has a property called MenuFoodItems that represents a collection of MenuFoodItem objects. 
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{// this class represent menu with multiple fooditems. with Name and optional description
    public class Menu
    {
        [Key]// unique identifier
        public int MenuId { get; set; }
       
        public required string MenuName { get; set; }
        public List<FoodBooking>? FoodBookings { get; set; }
        public List<MenuFoodItem>? MenuFoodItems { get; set; }
    }
}
