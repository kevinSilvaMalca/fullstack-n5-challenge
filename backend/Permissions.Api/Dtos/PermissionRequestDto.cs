namespace Dtos;

public class PermissionRequestDto
{
    public string EmployeeName { get; set; } = null!;
    public string EmployeeLastName { get; set; } = null!;
    public int PermissionTypeId { get; set; }
    public DateTime PermissionDate { get; set; }
}
