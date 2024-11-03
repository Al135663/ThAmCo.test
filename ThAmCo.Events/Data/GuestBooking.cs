namespace ThAmCo.Events.Data
{

    //represent the booking of a guest for a event.
    //this is a junction table establishing the many to many relationship between guests and Events.
    public class GuestBooking
    {
        public int GuestId {  get; set; }// Foreign key referencing the associating guest.

        //navigation property to the guest attending the event (non_nullable)
        public required Guest Guest {  get; set; } 

        public int EventId { get; set; }// Foreign key referencing associated events

        public required Event Event { get; set; }// navigation property to the event that the guest is booked.


        //status of guest attendance(cancelled, confirmed, Attended)
        public string? AttendanceStatus { get; set; }// unknown status at the time of biooking can be added later.
    }
}
