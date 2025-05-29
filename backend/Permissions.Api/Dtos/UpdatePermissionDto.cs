namespace Dtos;

public class UpdatePermissionDto
{
    public int Id { get; set; }
    public string? EmployeeName { get; set; }
    public string? EmployeeLastName { get; set; }
    public int? PermissionTypeId { get; set; }
    public DateTime? PermissionDate { get; set; }
}
