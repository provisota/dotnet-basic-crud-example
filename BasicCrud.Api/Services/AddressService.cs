using BasicCrud.Api.Dtos;
using BasicCrud.Api.Models;
using BasicCrud.Api.Repositories;

namespace BasicCrud.Api.Services
{
    /// <summary>
    /// Business logic for Addresses.
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;

        public AddressService(IAddressRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AddressDto>> GetAllAsync(CancellationToken ct = default)
            => (await _repo.GetAllAsync(ct)).Select(ToDto).ToList();

        public async Task<AddressDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var ent = await _repo.GetByIdAsync(id, ct);
            return ent is null ? null : ToDto(ent);
        }

        public async Task<AddressDto> CreateAsync(UpsertAddressDto dto, CancellationToken ct = default)
        {
            var entity = new Address { Street = dto.Street, City = dto.City };
            var created = await _repo.CreateAsync(entity, ct);
            return ToDto(created);
        }

        public async Task<AddressDto?> UpdateAsync(int id, UpsertAddressDto dto, CancellationToken ct = default)
        {
            var updated = await _repo.UpdateAsync(id, new Address { Street = dto.Street, City = dto.City }, ct);
            return updated is null ? null : ToDto(updated);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _repo.DeleteAsync(id, ct);

        private static AddressDto ToDto(Address a) => new()
        {
            Id = a.Id,
            Street = a.Street,
            City = a.City
        };
    }
}
