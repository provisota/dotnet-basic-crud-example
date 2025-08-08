using BasicCrud.Api.Models;

namespace BasicCrud.Api.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAsync(CancellationToken ct = default);
        Task<Address?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Address> CreateAsync(Address address, CancellationToken ct = default);
        Task<Address?> UpdateAsync(int id, Address updated, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
