using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentService.Models
{
    [Table("Students")]
	public class Student
	{
        
        public Int64 Id { get; set; }
        [Required, StringLength(25)]
        public string FirstName { get; set; }
        [Required, StringLength(25)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [Required, StringLength(15)]
        public string ContactNumber { get; set; }

    }
}

