namespace EfCoreInheritance{
    public class EmployeeRepository{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public IEnumerable<EmployeeModel> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }
    public void AddEmployee(EmployeeModel employeeModel)
    {
        _context.Employees.Add(employeeModel);
        _context.SaveChanges();
    }
}

}