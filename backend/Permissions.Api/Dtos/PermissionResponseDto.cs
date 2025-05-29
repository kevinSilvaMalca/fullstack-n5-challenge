namespace Dtos;

public class PermissionResponseDto
{
    public int Id { get; set; }
    public string EmployeeName { get; set; } = null!;
    public string EmployeeLastName { get; set; } = null!;
    public string PermissionType { get; set; } = null!;
    public DateTime PermissionDate { get; set; }
}
