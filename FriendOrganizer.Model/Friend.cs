using System.ComponentModel.DataAnnotations;

namespace FriendOrganizer.Model
{
    public class Friend
    {
        public int Id { get; set; }

        //Annotation. Rules that apply on input 
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }
 
        [StringLength(50)]
        public string Email { get; set; }




    }
}
