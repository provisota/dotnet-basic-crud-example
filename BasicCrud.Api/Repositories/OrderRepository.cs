using BasicCrud.Api.Data;
using BasicCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Api.Repositories
{
    /// <summary>
    /// Repository for Order entity using EF Core.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<List<Order>> GetAllAsync(CancellationToken ct = default)
            => _db.Orders.AsNoTracking().OrderBy(o => o.Id).ToListAsync(ct);

        public Task<Order?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, ct);

        public async Task<Order> CreateAsync(Order order, CancellationToken ct = default)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync(ct);
            return order;
        }

        public async Task<Order?> UpdateAsync(int id, Order updated, CancellationToken ct = default)
        {
            var entity = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id, ct);
            if (entity == null) return null;

            entity.Item = updated.Item;
            entity.Quantity = updated.Quantity;
            await _db.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id, ct);
            if (entity == null) return false;

            _db.Orders.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
