using LabServer.DAL.Data;
using LabServer.DAL.Entities;
using LabServer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabServer.DAL.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _context;

    public GroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Group?> GetByIdAsync(int id)
    {
        return await _context.Groups
            .Include(g => g.Students)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Group?> GetByNameAsync(string name)
    {
        return await _context.Groups
            .FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task<List<Group>> GetAllAsync()
    {
        return await _context.Groups
            .Include(g => g.Students)
            .ToListAsync();
    }

    public async Task AddAsync(Group group)
    {
        await _context.Groups.AddAsync(group);
    }
}