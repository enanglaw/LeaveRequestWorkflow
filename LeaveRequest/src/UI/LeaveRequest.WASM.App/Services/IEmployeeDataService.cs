using LeaveRequest.Domain.Entity;

namespace LeaveRequest.WASM.App.Services
{
    public interface IEmployeeDataService
    {
         Task<Employee> AddEmployee(Employee employee);
         Task UpdateEmployee(Employee employee);
         Task<IEnumerable<Employee>> GetEmployees();
         Task<Employee> GetEmployeeDetails(int employeeId);
         Task DeleteEmployee(int employeeId);
    }
}
