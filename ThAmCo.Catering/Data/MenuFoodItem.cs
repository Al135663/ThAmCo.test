

using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        [Key]
        public int MenuId { get; set; }// foreign key referencing the associated fooditem.
        
        [Key]
        public int FoodItemId { get; set; } // Navigation property for associated fooditem

        public Menu? Menu { get; set; }
        public FoodItem? FoodItem { get; set; }

    }
}
