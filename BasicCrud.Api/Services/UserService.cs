using BasicCrud.Api.Dtos;
using BasicCrud.Api.Models;
using BasicCrud.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Api.Services
{
    /// <summary>
    /// Business logic for Users. Maps between DTOs and entities.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UserDto>> GetAllAsync(CancellationToken ct = default)
            => (await _repo.GetAllAsync(ct)).Select(ToDto).ToList();

        public async Task<UserDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var ent = await _repo.GetByIdAsync(id, ct);
            return ent is null ? null : ToDto(ent);
        }

        public async Task<UserDto> CreateAsync(UpsertUserDto dto, CancellationToken ct = default)
        {
            var entity = new User { Name = dto.Name, Email = dto.Email };
            var created = await _repo.CreateAsync(entity, ct);
            return ToDto(created);
        }

        public async Task<UserDto?> UpdateAsync(int id, UpsertUserDto dto, CancellationToken ct = default)
        {
            var updated = await _repo.UpdateAsync(id, new User { Name = dto.Name, Email = dto.Email }, ct);
            return updated is null ? null : ToDto(updated);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
            => _repo.DeleteAsync(id, ct);

        private static UserDto ToDto(User u) => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        };
    }
}
