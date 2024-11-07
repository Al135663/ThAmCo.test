using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Events.Data
{
    // Represents an event managed by ThAmCo.
    public class Event
    {
        // Primary key for the Event entity.
        [Key]
        public int EventId { get; set; }

        // Title of the event, required.
       
        public required string Title { get; set; }

        // Date when the event will occur.
        public DateTime Date { get; set; }

        // Foreign key referencing the venue for the event.
        public int VenueId { get; set; }

        // Maximum number of guests allowed for the event.
        public int GuestCapacity { get; set; }

        // List of guest bookings associated with this event.
        public List<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();

        // List of food bookings associated with this event.
        public List<FoodBooking> FoodBookings { get; set; } = new List<FoodBooking>();

        // List of staff assigned to this event.
        public List<Staffing> Staffings { get; set; } = new List<Staffing>();
    }
}