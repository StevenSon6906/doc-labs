namespace LabServer.DAL.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}