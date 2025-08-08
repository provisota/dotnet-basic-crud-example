using BasicCrud.Api.Dtos;

namespace BasicCrud.Api.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync(CancellationToken ct = default);
        Task<UserDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<UserDto> CreateAsync(UpsertUserDto dto, CancellationToken ct = default);
        Task<UserDto?> UpdateAsync(int id, UpsertUserDto dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
