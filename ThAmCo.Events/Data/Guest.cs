using System.ComponentModel.DataAnnotations;


namespace ThAmCo.Events.Data
{
    //Represent guest attending ThAmCo events, containing guests personal information
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }// unique identifier for each guest

        [StringLength(100)]
        public required string Name { get; set; }// Required guest name with maximum length of 100 character.

        [StringLength(200)]
        public string? ContactDetails { get; set; }// guest contact details such as email, phone number, address. Optional
    }
}
