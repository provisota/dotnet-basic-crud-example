using BasicCrud.Api.Data;
using BasicCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Api.Repositories
{
    /// <summary>
    /// Repository for Address entity using EF Core.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _db;

        public AddressRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<List<Address>> GetAllAsync(CancellationToken ct = default)
            => _db.Addresses.AsNoTracking().OrderBy(a => a.Id).ToListAsync(ct);

        public Task<Address?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);

        public async Task<Address> CreateAsync(Address address, CancellationToken ct = default)
        {
            _db.Addresses.Add(address);
            await _db.SaveChangesAsync(ct);
            return address;
        }

        public async Task<Address?> UpdateAsync(int id, Address updated, CancellationToken ct = default)
        {
            var entity = await _db.Addresses.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null) return null;

            entity.Street = updated.Street;
            entity.City = updated.City;
            await _db.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.Addresses.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null) return false;

            _db.Addresses.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
