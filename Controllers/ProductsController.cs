using Microsoft.AspNetCore.Mvc;

namespace SerilogTask.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        _logger.LogInformation("Getting product with ID {ProductId}", id);

        if (id <= 0)
        {
            _logger.LogWarning("Invalid product ID: {ProductId}", id);
            return BadRequest("Invalid product ID");
        }

        if (id == 99)
        {
            try
            {
                throw new InvalidOperationException("Test exception");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve product {ProductId}", id);
                return StatusCode(500, "Something went wrong");
            }
        }

        return Ok(new { Id = id, Name = "Laptop" });
    }
}