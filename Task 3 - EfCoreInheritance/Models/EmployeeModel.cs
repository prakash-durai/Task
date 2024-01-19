namespace EfCoreInheritance{
    public class EmployeeModel
{
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime HireDate { get; set; }
    public EmployeeModel? Manager { get; set; }
}
public class Manager : EmployeeModel
{
    public string? Department { get; set; }
}

public class RegularEmployee : EmployeeModel
{
    public string? Position { get; set; }
}
}
