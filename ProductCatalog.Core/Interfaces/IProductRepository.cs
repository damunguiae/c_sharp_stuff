using ProductCatalog.Core.Entities;

namespace ProductCatalog.Core.Interfaces
{
    /// <summary>
    /// Repository contract for Product data access operations.
    /// Implemented in Infrastructure layer, consumed in Core services.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<(IEnumerable<Product>,int totalCount)> GetAllAsync(string category, decimal minPrice, decimal maxPrice, int skip, int take);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
