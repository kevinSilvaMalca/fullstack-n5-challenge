using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Permission>> GetAllAsync() =>
        await _context.Permissions.Include(p => p.PermissionType).ToListAsync();

    public async Task<Permission?> GetByIdAsync(int id) =>
        await _context.Permissions.Include(p => p.PermissionType).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Permission> CreateAsync(Permission permission)
    {
        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();

        return await _context.Permissions
            .Include(p => p.PermissionType)
            .FirstAsync(p => p.Id == permission.Id);
    }

    public async Task<Permission?> UpdateAsync(Permission permission)
    {
        var existing = await _context.Permissions.FindAsync(permission.Id);
        if (existing == null) return null;

        _context.Entry(existing).CurrentValues.SetValues(permission);
        await _context.SaveChangesAsync();
        return existing;
    }
}
