using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.WebAPI.DTOs;

namespace ProductCatalog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(
        IProductService productService,
        ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        var productDtos = products.Select(p => new ProductDto
        (
            p.Id, p.Name, p.Description, p.Price, p.StockQuantity, p.ImageUrl, p.Rating, p.CreatedAt, p.UpdatedAt
        ));

        return Ok(productDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetProductAsync(id);

        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found." });

        var productDto = new ProductDto(
            product.Id, product.Name, product.Description,
            product.Price, product.StockQuantity, product.ImageUrl, product.Rating, product.CreatedAt, product.UpdatedAt);

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductRequest request)
    {
        try
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            };

            var created = await _productService.CreateProductAsync(product);
            var productDto = new ProductDto(
                created.Id, created.Name, created.Description,
                created.Price, created.StockQuantity, created.ImageUrl, created.Rating, created.CreatedAt, created.UpdatedAt);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, productDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductRequest request)
    {
        try
        {
            var product = new Product
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity
            };

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}