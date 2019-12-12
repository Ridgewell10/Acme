using AcmeEntities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeContracts
{
    public interface GetEmployeeByIdAsync : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int Id, Employee employee);
        void DeleteEmployee(int  Id,Employee employee);
    }
}

