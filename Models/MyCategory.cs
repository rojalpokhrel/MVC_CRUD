using System.ComponentModel.DataAnnotations;

namespace ThisIsIt.Models
{
    public class MyCategory
    {
        [Key]
            public int Id { get; set; }
        [Required]
            public string Name { get; set; }
        [Range(1,12)]
        public int Class { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter proper contact details.")]
        [Required]
        [Display(Name = "PhoneNumber")]
      
        public string PhoneNumber{ get; set; }

     

    }
}
