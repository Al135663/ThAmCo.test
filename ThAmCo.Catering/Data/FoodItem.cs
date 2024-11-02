using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    //This class Represent a food item in the catering system. each food has Name, Description and price.
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; } // Sets as a primary key. unique identifier number for each fooditem.

        [Required] // Data annotation that ensures Name can not be Null and maximum length of 50.
        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength (500)] // Maximum length of 500
        public string? Description { get; set; } // Discription property is Nullable. provides additional detals.

        [Range (0, 1000)] // setting range to prevent any invalid entry such as negetive value
        public decimal Price { get; set; } // Using decimal for accuracy
    }
}
