using Dtos;

namespace Services;

public interface IPermissionService
{
    Task<IEnumerable<PermissionResponseDto>> GetAllAsync();
    Task<PermissionResponseDto?> RequestAsync(PermissionRequestDto dto);
    Task<PermissionResponseDto?> ModifyAsync(UpdatePermissionDto dto);
}
