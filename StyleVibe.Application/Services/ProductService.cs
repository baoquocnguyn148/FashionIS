using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;

namespace StyleVibe.Application.Services;

public class ProductService(IAppDbContext context) : IProductService
{
    public async Task<IEnumerable<Product>> GetActiveProductsAsync(CancellationToken cancellationToken = default)
    {
        return await context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => p.IsActive && !p.IsDeleted)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Include(p => p.Skus.Where(sku => sku.IsActive && !sku.IsDeleted))
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);
    }

    public async Task<IEnumerable<ProductSku>> GetProductSkusByProductIdAsync(int productId, CancellationToken cancellationToken = default)
    {
        return await context.ProductSkus
            .Where(sku => sku.ProductId == productId && sku.IsActive && !sku.IsDeleted)
            .OrderBy(sku => sku.Size)
            .ThenBy(sku => sku.Color)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductSku?> GetProductSkuByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.ProductSkus
            .Include(sku => sku.Product)
            .FirstOrDefaultAsync(sku => sku.Id == id && sku.IsActive && !sku.IsDeleted, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        return await context.Products
            .Include(p => p.Category)
            .Where(p => p.CategoryId == categoryId && p.IsActive && !p.IsDeleted)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await context.Categories
            .Where(c => !c.IsDeleted)
            .OrderBy(c => c.DisplayOrder)
            .ThenBy(c => c.Name)
            .ToListAsync(cancellationToken);
    }
}
