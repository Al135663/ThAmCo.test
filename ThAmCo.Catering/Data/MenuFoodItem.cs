

using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    // Represents the relationship between a Menu and a FoodItem, allowing many-to-many association.
    // Each instance of this class links a specific Menu to a specific FoodItem.
    public class MenuFoodItem
    {

      
        [Key]
        public int MenuId { get; set; }// foreign key referencing the associated fooditem.
        
        [Key]
        public int FoodItemId { get; set; } // Foreign key referencing the associated FoodItem.


        //// Navigation property to the related Menu entity.
        // Nullable to allow flexibility in cases where the Menu may not be loaded.
        public Menu? Menu { get; set; }


        // Navigation property to the related FoodItem entity.
        // Nullable to allow flexibility in cases where the FoodItem may not be loaded.
        public FoodItem? FoodItem { get; set; }

    }
}
