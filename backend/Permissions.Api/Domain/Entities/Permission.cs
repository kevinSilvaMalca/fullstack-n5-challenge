namespace Domain.Entities;
public class Permission
{
    public int Id { get; set; }
    public string EmployeeName { get; set; } = null!;
    public string EmployeeLastName { get; set; } = null!;
    public int PermissionTypeId { get; set; }
    public DateTime PermissionDate { get; set; }

    public PermissionType PermissionType { get; set; } = null!;
}
