using System;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{//This class representing food booking associating with an event.
    // records a menu that has been booked for a particular event.
    public class FoodBooking
    {
        //primary key. Unique identifier for each FoodBooking
        [Key]
        public int FoodBookinId { get; set; }

        public int ClientReferenceId { get; set; } // Represents a reference to the client or event booking.

        public int NumberOfGuests { get; set; } // Number of guests covered by this food booking. Ensures sufficient food is provided based on guest count.


        // Foreign key referencing the associated menu that was booked for this event.
        public int MenuId { get; set; }// Identifier of the menu been booked.



        // Navigation property to the associated Menu entity.
        // Allows access to details about the menu that has been booked.
        public Menu? Menu { get; set; }  // Nullable to handle cases where the menu details may not be loaded
    }
}
