using LabServer.BLL.Interfaces;
using LabServer.BLL.Models;
using LabServer.DAL.Interfaces;

namespace LabServer.BLL.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<StudentDto>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();

        return students.Select(s => new StudentDto
        {
            Id = s.Id,
            Name = s.Name,
            GroupName = s.Group.Name
        });
    }

    public async Task<StudentDto?> GetByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);

        if (student == null)
        {
            return null;
        }

        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            GroupName = student.Group.Name
        };
    }
}