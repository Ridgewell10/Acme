using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AcmeEntities.Models;
using AcmeEntities;
using AcmeContracts;

namespace AcmeRepository

{
    public class EmployeeRepository : RepositoryBase<Employee>, GetEmployeeByIdAsync

    {
        public EmployeeRepository(AcmeContext acmeContext)
                 : base(acmeContext)
        {
        }

        public void AddEmployee(Employee employee)
        {
            Create(employee);
            Save();
        }

        public void DeleteEmployee(int Id, Employee employee)
        {
           Delete(employee);
           Save();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {

            return await FindAll()
                .OrderBy(co => co.Id)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await FindByCondition(employee => employee.Id.Equals(employeeId))
            .DefaultIfEmpty(new Employee())
            .FirstOrDefaultAsync();
        }

        public void UpdateEmployee(int Id, Employee employee)
        {
            Update(employee);
            Save();
        }
    }
}
