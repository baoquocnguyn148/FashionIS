using StyleVibe.Domain.Entities;

namespace StyleVibe.Application.Interfaces;

public interface IPosService
{
    Task<Order> CreateOrderAsync(
        int storeId,
        int? customerId,
        IEnumerable<(int productSkuId, int quantity, decimal discountPercent)> items,
        byte paymentMethod,
        string? note = null,
        string? customerName = null,
        string? phone = null,
        string? address = null,
        string? voucherCode = null,
        CancellationToken cancellationToken = default);
}

