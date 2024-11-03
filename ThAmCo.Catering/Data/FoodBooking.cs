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

        public int ClientReferenceId { get; set; }// liks booking to specific event.

        public int NumberOfGuests { get; set; }
        public int MenuId { get; set; }// Identifier of the menu been booked.

        
        public Menu? Menu { get; set; }
    }
}
