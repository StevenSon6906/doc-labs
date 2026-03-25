namespace LabServer.DAL.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
}