using BasicCrud.Api.Dtos;
using BasicCrud.Api.Models;
using BasicCrud.Api.Repositories;

namespace BasicCrud.Api.Services
{
    /// <summary>
    /// Business logic for Orders. Maps between DTOs and entities.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<OrderDto>> GetAllAsync(CancellationToken ct = default)
            => (await _repo.GetAllAsync(ct)).Select(ToDto).ToList();

        public async Task<OrderDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var ent = await _repo.GetByIdAsync(id, ct);
            return ent is null ? null : ToDto(ent);
        }

        public async Task<OrderDto> CreateAsync(UpsertOrderDto dto, CancellationToken ct = default)
        {
            var entity = new Order { Item = dto.Item, Quantity = dto.Quantity };
            var created = await _repo.CreateAsync(entity, ct);
            return ToDto(created);
        }

        public async Task<OrderDto?> UpdateAsync(int id, UpsertOrderDto dto, CancellationToken ct = default)
        {
            var updated = await _repo.UpdateAsync(id, new Order { Item = dto.Item, Quantity = dto.Quantity }, ct);
            return updated is null ? null : ToDto(updated);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _repo.DeleteAsync(id, ct);

        private static OrderDto ToDto(Order o) => new OrderDto
        {
            Id = o.Id,
            Item = o.Item,
            Quantity = o.Quantity
        };
    }
}
