using Dtos;
using Domain.Entities;
using Infrastructure.Repositories;
using Elasticsearch.Net;
using Confluent.Kafka;

namespace Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _repository;
    private readonly IElasticLowLevelClient _elastic;
    private readonly IProducer<Null, string> _producer;

    public PermissionService(
        IPermissionRepository repository,
        IProducer<Null, string> producer,
        IElasticLowLevelClient elastic
    )
    {
        _repository = repository;
        _producer = producer;
        _elastic = elastic;
    }
    public async Task<IEnumerable<PermissionResponseDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(p => new PermissionResponseDto
        {
            Id = p.Id,
            EmployeeName = p.EmployeeName,
            EmployeeLastName = p.EmployeeLastName,
            PermissionType = p.PermissionType.Description,
            PermissionDate = p.PermissionDate
        });
    }

    public async Task<PermissionResponseDto?> RequestAsync(PermissionRequestDto dto)
    {
        var permission = new Permission
        {
            EmployeeName = dto.EmployeeName,
            EmployeeLastName = dto.EmployeeLastName,
            PermissionTypeId = dto.PermissionTypeId,
            PermissionDate = dto.PermissionDate
        };

        var created = await _repository.CreateAsync(permission);

        await IndexPermissionAsync(created);

        return new PermissionResponseDto
        {
            Id = created.Id,
            EmployeeName = created.EmployeeName,
            EmployeeLastName = created.EmployeeLastName,
            PermissionType = created.PermissionType.Description,
            PermissionDate = created.PermissionDate
        };

    }

    public async Task<PermissionResponseDto?> ModifyAsync(UpdatePermissionDto dto)
    {
        var existing = await _repository.GetByIdAsync(dto.Id);
        if (existing == null) return null;

        if (dto.EmployeeName != null) existing.EmployeeName = dto.EmployeeName;
        if (dto.EmployeeLastName != null) existing.EmployeeLastName = dto.EmployeeLastName;
        if (dto.PermissionTypeId.HasValue) existing.PermissionTypeId = dto.PermissionTypeId.Value;
        if (dto.PermissionDate.HasValue) existing.PermissionDate = dto.PermissionDate.Value;

        var updated = await _repository.UpdateAsync(existing);

        await IndexPermissionAsync(updated);

        return new PermissionResponseDto
        {
            Id = updated!.Id,
            EmployeeName = updated.EmployeeName,
            EmployeeLastName = updated.EmployeeLastName,
            PermissionType = updated.PermissionType.Description,
            PermissionDate = updated.PermissionDate
        };
    }

    private async Task IndexPermissionAsync(Permission permission)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(new
        {
            permission.Id,
            permission.EmployeeName,
            permission.EmployeeLastName,
            permission.PermissionTypeId,
            permission.PermissionDate
        });

        await _elastic.IndexAsync<StringResponse>("permissions", permission.Id.ToString(), PostData.String(json));
    }
}
