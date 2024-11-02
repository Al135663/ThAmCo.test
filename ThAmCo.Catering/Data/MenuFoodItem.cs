

namespace ThAmCo.Catering.Data
{// join table for many to many relationship of Menu and FoodItem
    // this class holds foreign key for Menu and Fooditem.
    public class MenuFoodItem
    {
        
        public int MenuId { get; set; }// Foreign key referencing associated Menu.
        public required Menu Menu { get; set; }// Navigation property for associated Menu.
        public int FoodItemId { get; set; }// foreign key referencing the associated fooditem.
        public required FoodItem FoodItem { get; set; } // Navigation property for associated fooditem
    }
}
