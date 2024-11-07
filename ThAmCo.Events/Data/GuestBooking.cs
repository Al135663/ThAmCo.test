using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Events.Data
{
    // Represents a booking record for a guest at an event.
    public class GuestBooking
    {
        // Primary key for the GuestBooking entity.
        [Key]
        public int BookingId { get; set; }

        // Foreign key referencing the Guest.
        public required string GuestId { get; set; }

        // Foreign key referencing the Event.
        public int EventId { get; set; }

        // Navigation property to the Guest entity.
        [ForeignKey("GuestId")]
        public required Guest Guest { get; set; }

        // Navigation property to the Event entity.
        [ForeignKey("EventId")]
        public required Event Event { get; set; }
    }
}