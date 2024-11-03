using System.ComponentModel.DataAnnotations;// Added for data annotation such as Required/Key, etc.....

namespace ThAmCo.Events.Data
{//This class represents a member of staff working for ThAmCo and assign members to work at events.
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }// Unique identifier for each staff member


        [StringLength(100)]
        public required string Name {  get; set; }//Name of staff member. Required with maximum length of 100 character.
                                                  
        [StringLength(100)]
        public required string Position { get; set; }//Required staff position to describe role or job title.

        
    }
}
