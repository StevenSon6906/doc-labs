using LabServer.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabServer.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImportController : ControllerBase
{
    private readonly IImportService _importService;

    public ImportController(IImportService importService)
    {
        _importService = importService;
    }

    [HttpPost("from-csv")]
    public async Task<IActionResult> ImportFromCsv([FromQuery] string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return BadRequest("Path to CSV file is required.");
        }

        if (!System.IO.File.Exists(path))
        {
            return NotFound($"File not found: {path}");
        }

        await _importService.ImportFromCsvAsync(path);

        return Ok(new
        {
            message = "Data imported successfully.",
            filePath = path
        });
    }
}