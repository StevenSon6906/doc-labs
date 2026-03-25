namespace LabServer.BLL.Interfaces;

public interface IImportService
{
    Task ImportFromCsvAsync(string path);
}