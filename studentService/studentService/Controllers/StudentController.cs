using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using studentService.DTOs;
using studentService.entitys;

namespace studentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly SchoolContext _context;
    private readonly IMapper _mapper;

    public StudentController(SchoolContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<StudentDTO> GetAllStudents()
    {
        var students = _context.Students;
        return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
    }
}