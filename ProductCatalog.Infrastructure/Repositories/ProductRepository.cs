using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Interfaces;
using ProductCatalog.Infrastructure.Data;

namespace ProductCatalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    /// <summary>
    /// Method to retrieve products by category and price range with pagination.
    /// </summary>
    /// <param name="category"></param>
    /// <param name="minPrice"></param>
    /// <param name="maxPrice"></param>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>
    public async Task<(IEnumerable<Product>,int totalCount)> GetAllAsync(string category, decimal minPrice, decimal maxPrice, int skip, int take)
    {   
        var query = _context.Products.Where(p => (!string.IsNullOrEmpty(p.Category) && p.Category.ToLower() == category.ToLower()) || category == "all")
            .Where(p => p.Price >= minPrice)
            .Where(p => p.Price <= maxPrice);
        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(p => p.Category)
            .ThenBy(p => p.Price)
            .Skip(skip)      
            .Take(take) 
            .ToListAsync();

        return (items, totalCount);
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Products.AnyAsync(p => p.Id == id);
    }
}