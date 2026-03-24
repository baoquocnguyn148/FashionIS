using StyleVibe.Domain.Entities;

namespace StyleVibe.Application.Interfaces;

public interface IPurchaseOrderService
{
    Task<PurchaseOrder> CreatePurchaseOrderAsync(
        int supplierId,
        IEnumerable<(int skuId, int quantity, decimal unitCost)> items,
        string? note = null,
        CancellationToken cancellationToken = default);

    Task<List<PurchaseOrder>> GetAllPurchaseOrdersAsync(CancellationToken cancellationToken = default);
    
    Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id, CancellationToken cancellationToken = default);
}
