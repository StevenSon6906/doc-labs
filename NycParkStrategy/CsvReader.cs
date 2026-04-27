using CsvHelper;
using CsvHelper.Configuration;
using NycParkStrategy.Models;
using System.Globalization;

namespace NycParkStrategy;

public static class DataReader
{
    public static IEnumerable<ParkingViolation> Read(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            BadDataFound = null,       
            MissingFieldFound = null   
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);

        foreach (var record in csv.GetRecords<ParkingViolation>())
        {
            yield return record;
        }
    }
}