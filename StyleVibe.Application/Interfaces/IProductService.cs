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
}
