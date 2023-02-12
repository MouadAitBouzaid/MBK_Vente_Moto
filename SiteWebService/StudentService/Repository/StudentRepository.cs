using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentService.DbContexts;
using StudentService.Models;
using StudentService.Models.Dtos;

namespace StudentService.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;



        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            List<Student>  students= await _context.Students.ToListAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentyId(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            return _mapper.Map<Student, StudentDto>(student);
        }

        public async Task<StudentDto> CreateUpdateStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<StudentDto, Student>(studentDto);

            if (student.Id == 0)
            {
                await _context.Students.AddAsync(student);
            }
            else
            {
                _context.Students.Update(student);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Student, StudentDto>(student);
        }

        public async Task<StudentDto> DeleteStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return null;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return _mapper.Map<Student, StudentDto>(student);
        }

    }
}

