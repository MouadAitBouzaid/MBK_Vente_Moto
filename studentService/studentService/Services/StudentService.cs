using AutoMapper;
using studentService;
using studentService.DTOs;
using studentService.entitys;

public class StudentService
{
    private readonly SchoolContext _context;
    private readonly IMapper _mapper;

    public StudentService(SchoolContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<StudentDTO> GetAllStudents()
    {
        var students = _context.Students;
        return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(students);
    }
}