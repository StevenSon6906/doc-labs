using LabServer.DAL.Entities;

namespace LabServer.DAL.Interfaces;

public interface IGroupRepository
{
    Task<Group?> GetByIdAsync(int id);
    Task<Group?> GetByNameAsync(string name);
    Task<List<Group>> GetAllAsync();
    Task AddAsync(Group group);
}