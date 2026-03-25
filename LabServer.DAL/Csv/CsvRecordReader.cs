using CsvHelper;
using LabServer.DAL.Interfaces;
using System.Globalization;

namespace LabServer.DAL.Csv;

public class CsvRecordReader : ICsvReader<CsvRecord>
{
    public IEnumerable<CsvRecord> Read(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return csv.GetRecords<CsvRecord>().ToList();
    }
}