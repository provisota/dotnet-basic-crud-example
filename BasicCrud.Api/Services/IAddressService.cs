using BasicCrud.Api.Dtos;

namespace BasicCrud.Api.Services
{
    public interface IAddressService
    {
        Task<List<AddressDto>> GetAllAsync(CancellationToken ct = default);
        Task<AddressDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<AddressDto> CreateAsync(UpsertAddressDto dto, CancellationToken ct = default);
        Task<AddressDto?> UpdateAsync(int id, UpsertAddressDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
