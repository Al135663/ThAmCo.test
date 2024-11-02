using System;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{//This class representing food booking associating with an event.
    // records a menmu that has been booked for a particular event.
    public class FoodBooking
    {
        //Unique identifier for each FoodBooking
        [Key]
        public int FoodBookinId { get; set; }

        public int EventId { get; set; }// liks booking to specific event.

        public int MenuId { get; set; }// Identifier of the menu been booked.

        [Required]
        public DateTime DateBooked { get; set; }// Date when booking was made.
        public Menu? Menu { get; set; }  // Navigation property to the menu that is part of booking.
        // It is nullable, Booking can be made whitout the menu initially and menu is assigned later.
    }
}
