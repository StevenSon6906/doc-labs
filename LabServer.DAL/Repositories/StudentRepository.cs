using LabServer.DAL.Data;
using LabServer.DAL.Entities;
using LabServer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabServer.DAL.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Group)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student?> GetByNameAsync(string name)
    {
        return await _context.Students
            .Include(s => s.Group)
            .FirstOrDefaultAsync(s => s.Name == name);
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.Group)
            .ToListAsync();
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }
}