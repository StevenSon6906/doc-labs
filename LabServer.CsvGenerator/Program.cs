using System.Text;

var solutionRoot = AppContext.BaseDirectory;
var projectRoot = Path.GetFullPath(Path.Combine(solutionRoot, "../../../../"));
var outputDir = Path.Combine(projectRoot, "data");

Directory.CreateDirectory(outputDir);

var filePath = Path.Combine(outputDir, "dataset.csv");
var random = new Random();

using var writer = new StreamWriter(filePath, false, Encoding.UTF8);

writer.WriteLine("StudentName,GroupName");

for (int i = 1; i <= 1000; i++)
{
    var studentName = $"Student_{i}";
    var groupName = $"Group_{random.Next(1, 21)}";
    writer.WriteLine($"{studentName},{groupName}");
}

Console.WriteLine($"CSV created: {filePath}");