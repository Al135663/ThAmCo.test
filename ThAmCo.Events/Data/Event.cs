using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    //represents an event(Wdding, Conference,etc )  managed by ThAmCo
    public class Event
    {
        [Key]
        public int EventId { get; set; }// unique identifier for each event

        [StringLength(100)]
        public required string Title { get; set; }// Required title with maximum length of 100 characters.
        public required DateTime date { get; set; }// Required date on which event takes place

        public required string Eventtype { get; set; }// Required field to specify the nature of event.
        public int? VenueId { get; set; }// Optional foriegn key representing the associated venue.
        // made it Nullable to allow events to be made without a venue.



        //Navigation property for guest booking related to this event
        // this enables access to the list of guest attending the venue.
        public ICollection<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();


        // Navigation property for staff assigned to work at this event. providing list of staff scheduled
        // to assist at the event. 
        public ICollection<Staffing> Staffing { get; set; } = new List<Staffing>();

    }
}
