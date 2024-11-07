using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    // Represents a staff member working for ThAmCo.
    public class Staff
    {
        // Primary key for the Staff entity.
        [Key]
        public int StaffId { get; set; }

        // Name of the staff member, required.
        
        public required string Name { get; set; }

        // Role or position of the staff member (e.g., Event Manager).
        public required string Role { get; set; }

        // List of events to which this staff member is assigned.
        public List<Staffing> Staffings { get; set; } = new List<Staffing>();
    }
}