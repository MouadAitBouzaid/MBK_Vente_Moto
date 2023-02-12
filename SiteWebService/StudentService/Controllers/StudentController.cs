using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentService.Models.Dtos;
using StudentService.Repository;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
        {
            var students = await _studentRepository.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentyId(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto studentDto)
        {
            var createdStudent = await _studentRepository.CreateUpdateStudent(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(int id, StudentDto studentDto)
        {
            studentDto.Id = id;
            var updatedStudent = await _studentRepository.CreateUpdateStudent(studentDto);
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var deletedStudent = await _studentRepository.DeleteStudent(id);
            if (deletedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}