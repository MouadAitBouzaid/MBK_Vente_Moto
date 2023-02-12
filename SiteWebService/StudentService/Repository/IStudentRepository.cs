using System;
using StudentService.Models;
using StudentService.Models.Dtos;

namespace StudentService.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudents() ;
        Task<StudentDto> GetStudentyId(int studentId);
        Task<StudentDto> CreateUpdateStudent(StudentDto studentDto);
        Task<StudentDto> DeleteStudent(int studentId);
    }

}
