using LabServer.BLL.Interfaces;
using LabServer.BLL.Models;
using LabServer.DAL.Entities;
using LabServer.DAL.Interfaces;
using LabServer.DAL.Csv;

namespace LabServer.BLL.Services;

public class ImportService : IImportService
{
    private readonly ICsvReader<CsvRecord> _csvReader;
    private readonly IStudentRepository _studentRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ImportService(
        ICsvReader<CsvRecord> csvReader,
        IStudentRepository studentRepository,
        IGroupRepository groupRepository,
        IUnitOfWork unitOfWork)
    {
        _csvReader = csvReader;
        _studentRepository = studentRepository;
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ImportFromCsvAsync(string path)
    {
        var rows = _csvReader.Read(path);

        foreach (var row in rows)
        {
            if (string.IsNullOrWhiteSpace(row.StudentName) ||
                string.IsNullOrWhiteSpace(row.GroupName))
            {
                continue;
            }

            var normalizedGroupName = row.GroupName.Trim();
            var normalizedStudentName = row.StudentName.Trim();

            var group = await _groupRepository.GetByNameAsync(normalizedGroupName);

            if (group == null)
            {
                group = new Group
                {
                    Name = normalizedGroupName
                };

                await _groupRepository.AddAsync(group);
                await _unitOfWork.SaveChangesAsync();
            }

            var student = await _studentRepository.GetByNameAsync(normalizedStudentName);

            if (student == null)
            {
                student = new Student
                {
                    Name = normalizedStudentName,
                    GroupId = group.Id
                };

                await _studentRepository.AddAsync(student);
            }
        }

        await _unitOfWork.SaveChangesAsync();
    }
}