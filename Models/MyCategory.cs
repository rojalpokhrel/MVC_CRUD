using System.ComponentModel.DataAnnotations;

namespace ThisIsIt.Models
{
    public class MyCategory
    {
        [Key]
            public int Id { get; set; }
        [Required]
            public string Name { get; set; }
        public int Class { get; set; }
        public int PhoneNumber{ get; set; }
        }
}
