using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    // Represents a guest attending events.
    public class Guest
    {
        // Primary key for the Guest entity.
        [Key]
        public int GuestId { get; set; }

        // Name of the guest, required.
      
        public required string Name { get; set; }

        // Email address of the guest.
        public string? Email { get; set; }

        // List of bookings associated with this guest.
        public List<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();
    }
}