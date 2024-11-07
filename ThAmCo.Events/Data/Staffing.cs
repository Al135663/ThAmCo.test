using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Events.Data
{
    // Represents the assignment of a staff member to an event.
    public class Staffing
    {
        // Primary key for the Staffing entity.
        [Key]
        public int StaffingId { get; set; }

        // Foreign key referencing the Staff.
        public int StaffId { get; set; }

        // Foreign key referencing the Event.
        public int EventId { get; set; }

        // Navigation property to the Staff entity.
        [ForeignKey("StaffId")]
        public required Staff Staff { get; set; }

        // Navigation property to the Event entity.
        [ForeignKey("EventId")]
        public required Event Event { get; set; }
    }
}