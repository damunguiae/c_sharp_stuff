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
    public async Task<ActionResult<PagedResult<ProductDto>>> GetAll(
        [FromQuery] string category = "all",
        [FromQuery] decimal? minPrice = null,
        [FromQuery] decimal? maxPrice = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {

        // Validate pagination parameters
        if (pageNumber < 1)
            return BadRequest(new { message = "Page number must be at least 1." });

        // Calculate skip/take
        var skip = (pageNumber - 1) * pageSize;
        var take = pageSize;

        var (products,totalCount) = await _productService.GetAllProductsAsync(
            category,
            minPrice ?? 0,
            maxPrice ?? 1000,
            skip,
            take);

        var productDtos = products.Select(p => new ProductDto
        (
            p.Id, p.Name, p.Description, p.Price, p.StockQuantity, p.ImageUrl, p.Rating, p.Category, p.CreatedAt, p.UpdatedAt
        ));

        var result = new PagedResult<ProductDto>
        {
            Items = productDtos,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetProductAsync(id);

        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found." });

        var productDto = new ProductDto(
            product.Id, product.Name, product.Description,
            product.Price, product.StockQuantity, product.ImageUrl, product.Rating, product.Category, product.CreatedAt, product.UpdatedAt);

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
                StockQuantity = request.StockQuantity,
                Category = request.Category
            };

            var created = await _productService.CreateProductAsync(product);
            var productDto = new ProductDto(
                created.Id, created.Name, created.Description,
                created.Price, created.StockQuantity, created.ImageUrl, created.Rating, created.Category, created.CreatedAt, created.UpdatedAt);

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
                StockQuantity = request.StockQuantity,
                Category = request.Category
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