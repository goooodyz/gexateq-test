using gexateq_test_BE.Data.DTOs;
using gexateq_test_BE.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gexateq_test_BE.Services.EmployeeService
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeModel>> GetAllEmployee();

        public Task<EmployeeModel> GetEmployee(Guid id);

        public Task CreateEmployee(CreateEmployeeDto dto);

        public Task UpdateEmployee(UpdateEmployeeDto dto);

        public Task DeleteEmployee(Guid id);

        public Task<int> SetData(int count);
    }
}
