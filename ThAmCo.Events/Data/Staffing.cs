namespace ThAmCo.Events.Data
{
    //this class represents staff assignments to the events.
    // junction table establishing many to many relationship between Events and Staff.
    public class Staffing
    {
        public int StaffId { get; set; }// Foreign key referencing associating staff

        public required Staff Staff { get; set; }// 
    }
}
