using System.Collections.Generic; // provides access to ICollection<T>.Menu class has a property called MenuFoodItems that represents a collection of MenuFoodItem objects. 
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{// this class represent menu with multiple fooditems. with Name and optional description
    public class Menu
    {
        [Key]// unique identifier
        public int MenuId { get; set; }
        
        [StringLength(50)]// name of menu with 50 maximum length and can not be Null
        public required string Name { get; set; }
        [StringLength(500)]// maximum of 500 character
        public string? Description { get; set; }// provides more details about menu and is optional.

        //Collection of food item included in the menu
        // many to many relationship between menu and food item using menuFoodItem as a join table.
        public ICollection<MenuFoodItem> MenuFoodItem { get; set; } = new List<MenuFoodItem>();
    }
}
