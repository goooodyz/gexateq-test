using gexateq_test_BE.Data.Enums;
using gexateq_test_BE.Data.Models;
using gexateq_test_BE.Database.Entities;

namespace gexateq_test_BE.Data
{
    public static class Mapper
    {
        public static EmployeeModel EmployeeToModel(Employee employee)
        {
            if (employee is null) return null;

            return new EmployeeModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = Enum.GetName(typeof(GenderEnum), employee.Gender),
                Age = employee.Age,
            };
        }

        public static List<EmployeeModel> EmployeeToModel(List<Employee> employees)
        {
            if (employees is null || employees.Count == 0) return new List<EmployeeModel>();

            return employees.Select(EmployeeToModel).ToList();
        }
    }
}
