namespace ProductCatalog.WebAPI.DTOs;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string ImageUrl,
    int Rating,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string ImageUrl,
    int Rating
);

public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string ImageUrl,
    int Rating
);