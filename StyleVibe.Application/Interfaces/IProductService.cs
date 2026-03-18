using StyleVibe.Domain.Entities;

namespace StyleVibe.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetActiveProductsAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductSku>> GetProductSkusByProductIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<ProductSku?> GetProductSkuByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> SearchProductsAsync(
        string? keyword,
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy,        // "newest", "price_asc", "price_desc", "name" 
        CancellationToken cancellationToken = default);
    Task<Inventory?> GetInventoryAsync(int skuId, int storeId, CancellationToken ct = default);
}
