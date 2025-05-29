using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IPermissionRepository
{
    Task<List<Permission>> GetAllAsync();
    Task<Permission?> GetByIdAsync(int id);
    Task<Permission> CreateAsync(Permission permission);
    Task<Permission?> UpdateAsync(Permission permission);
}
