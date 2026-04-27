using CsvHelper.Configuration.Attributes;

namespace NycParkStrategy.Models;

public class ParkingViolation
{
    [Name("summons_number")]
    public string? SummonsNumber { get; set; }

    [Name("plate_id")]
    public string? PlateId { get; set; }

    [Name("registration_state")]
    public string? RegistrationState { get; set; }

    [Name("issue_date")]
    public string? IssueDate { get; set; }

    [Name("violation_code")]
    public string? ViolationCode { get; set; }

    [Name("vehicle_body_type")]
    public string? VehicleBodyType { get; set; }

    [Name("vehicle_make")]
    public string? VehicleMake { get; set; }
}