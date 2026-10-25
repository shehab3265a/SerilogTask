
using Microsoft.AspNetCore.Mvc;

namespace SerilogTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        _logger.LogInformation("Getting all products");

        var products = new[]
        {
            new { Id = 1, Name = "Laptop", Price = 25000 },
            new { Id = 2, Name = "Phone", Price = 15000 }
        };

        return Ok(products);
    }

    [HttpGet("error")]
    public IActionResult TestError()
    {
        try
        {
            throw new InvalidOperationException("Test exception for Serilog");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while testing Serilog");
            return Problem("A test error was logged successfully.");
        }
    }
}
