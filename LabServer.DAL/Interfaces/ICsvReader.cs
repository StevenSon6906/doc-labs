namespace LabServer.DAL.Interfaces;

public interface ICsvReader<T>
{
    IEnumerable<T> Read(string path);
}