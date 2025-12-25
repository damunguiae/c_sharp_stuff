using ProductCatalog.Core.Entities;

namespace ProductCatalog.Core.Interfaces
{
    /// <summary>
    /// Business logic service for Product operations.
    /// Contains business rules and validation logic.
    /// </summary>
    public interface IProductService
    {
        Task<Product?> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
