using Dtos;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionService _service;

    public PermissionsController(IPermissionService service)
    {
        _service = service;
    }

    // GET: /api/permissions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PermissionResponseDto>>> GetPermissions()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    // POST: /api/permissions/request
    [HttpPost("request")]
    public async Task<ActionResult<PermissionResponseDto>> RequestPermission([FromBody] PermissionRequestDto dto)
    {
        var result = await _service.RequestAsync(dto);
        return result is null ? BadRequest("Unable to create permission") : CreatedAtAction(nameof(GetPermissions), result);
    }

    // PUT: /api/permissions/modify
    [HttpPut("modify")]
    public async Task<ActionResult<PermissionResponseDto>> ModifyPermission([FromBody] UpdatePermissionDto dto)
    {
        var result = await _service.ModifyAsync(dto);
        return result is null ? NotFound("Permission not found") : Ok(result);
    }
}
