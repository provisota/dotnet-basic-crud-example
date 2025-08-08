using BasicCrud.Api.Data;
using BasicCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Api.Repositories
{
    /// <summary>
    /// Repository for User entity using EF Core.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<List<User>> GetAllAsync(CancellationToken ct = default)
            => _db.Users.AsNoTracking().OrderBy(u => u.Id).ToListAsync(ct);

        public Task<User?> GetByIdAsync(int id, CancellationToken ct = default)
            => _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, ct);

        public async Task<User> CreateAsync(User user, CancellationToken ct = default)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);
            return user;
        }

        public async Task<User?> UpdateAsync(int id, User updated, CancellationToken ct = default)
        {
            var entity = await _db.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
            if (entity == null) return null;

            entity.Name = updated.Name;
            entity.Email = updated.Email;
            await _db.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
            if (entity == null) return false;

            _db.Users.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
