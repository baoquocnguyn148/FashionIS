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

    public async Task<IEnumerable<Product>> SearchProductsAsync(
        string? keyword, int? categoryId,
        decimal? minPrice, decimal? maxPrice,
        string? sortBy, CancellationToken cancellationToken = default)
    {
        var query = context.Products
            .Include(p => p.Category)
            .Include(p => p.Skus.Where(s => s.IsActive && !s.IsDeleted))
            .Where(p => p.IsActive && !p.IsDeleted);

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(p => p.Name.Contains(keyword));

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        if (minPrice.HasValue)
            query = query.Where(p => p.Skus.Any(s => s.SellingPrice >= minPrice.Value));

        if (maxPrice.HasValue)
            query = query.Where(p => p.Skus.Any(s => s.SellingPrice <= maxPrice.Value));

        query = sortBy switch
        {
            "price_asc" => query.OrderBy(p => p.Skus.Min(s => s.SellingPrice)),
            "price_desc" => query.OrderByDescending(p => p.Skus.Max(s => s.SellingPrice)),
            "name" => query.OrderBy(p => p.Name),
            _ => query.OrderByDescending(p => p.CreatedAt) // "newest" is default 
        };

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Inventory?> GetInventoryAsync(int skuId, int storeId, CancellationToken ct = default)
    {
        return await context.Inventories
            .FirstOrDefaultAsync(i => i.ProductSkuId == skuId
                                   && i.StoreId == storeId
                                   && !i.IsDeleted, ct);
    }
}
