using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    //This class Represent a food item in the catering system. each food has Name, Description and price.
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; } // Sets as a primary key. unique identifier number for each fooditem.

        [StringLength(50)] // Maximum length of 50
        public string? Description { get; set; } // Discription property is Nullable. provides additional detals.

        [Range(0, 1000)] // setting range to prevent any invalid entry such as negetive value
        public decimal UnitPrice { get; set; } // Using decimal for accuracy


        public List<MenuFoodItem>? MenuFoodItems { get; set; }
        public object MenuFoodItem { get; internal set; }
    }
}
