namespace ThAmCo.Events.Data
{
    //this class represents staff assignments to the events.
    // junction table establishing many to many relationship between Events and Staff.
    public class Staffing
    {
        public int StaffId { get; set; }// Foreign key referencing associating staff

        public required Staff Staff { get; set; }// Required, Navigation property to the staff member assigned to the events. 


        public int EventId { get; set; }//Foreign key referencing the associated event.

        public required Event Event { get; set; }//Navigation property of the event that staff member is assigned to.(non-nullable)
    }
}
