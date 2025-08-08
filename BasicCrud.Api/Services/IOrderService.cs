using BasicCrud.Api.Dtos;

namespace BasicCrud.Api.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync(CancellationToken ct = default);
        Task<OrderDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<OrderDto> CreateAsync(UpsertOrderDto dto, CancellationToken ct = default);
        Task<OrderDto?> UpdateAsync(int id, UpsertOrderDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
