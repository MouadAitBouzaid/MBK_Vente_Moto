using System;
using System.ComponentModel.DataAnnotations;

namespace StudentService.Models.Dtos
{
	public class StudentDto
	{
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

    }
}

