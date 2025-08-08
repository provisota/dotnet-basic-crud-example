using BasicCrud.Api.Models;

namespace BasicCrud.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync(CancellationToken ct = default);
        Task<Order?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Order> CreateAsync(Order order, CancellationToken ct = default);
        Task<Order?> UpdateAsync(int id, Order updated, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
