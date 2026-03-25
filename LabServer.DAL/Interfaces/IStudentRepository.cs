using LabServer.DAL.Entities;

namespace LabServer.DAL.Interfaces;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id);
    Task<Student?> GetByNameAsync(string name);
    Task<List<Student>> GetAllAsync();
    Task AddAsync(Student student);
}