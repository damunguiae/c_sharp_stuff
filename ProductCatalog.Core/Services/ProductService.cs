using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Interfaces;

namespace ProductCatalog.Core.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            // Business rule: Validate product data
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name is required.", nameof(product.Name));

            if (product.Price <= 0)
                throw new ArgumentException("Product price must be greater than zero.", nameof(product.Price));

            product.CreatedAt = DateTime.UtcNow;
            return await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Business rule: Product must exist
            if (!await _productRepository.ExistsAsync(product.Id))
                throw new InvalidOperationException($"Product with ID {product.Id} does not exist.");

            product.UpdatedAt = DateTime.UtcNow;
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            // Business rule: Product must exist
            if (!await _productRepository.ExistsAsync(id))
                throw new InvalidOperationException($"Product with ID {id} does not exist.");

            await _productRepository.DeleteAsync(id);
        }
    }
}
