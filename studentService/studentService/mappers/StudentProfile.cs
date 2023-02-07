using AutoMapper;
using studentService.DTOs;
using studentService.entitys;

namespace studentService.mappers;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDTO>()
            .ReverseMap();
    }
}