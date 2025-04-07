using gexateq_test_BE.Database.Entities;
using gexateq_test_BE.Data.Enums;
using gexateq_test_BE.Database;
using Microsoft.EntityFrameworkCore;
using gexateq_test_BE.Data;
using gexateq_test_BE.Data.Models;
using gexateq_test_BE.Data.DTOs;

namespace gexateq_test_BE.Services.EmployeeService
{
    public sealed class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            var employees = Mapper.EmployeeToModel(await _context.Employee.ToListAsync());

            return employees;
        }

        public async Task<EmployeeModel> GetEmployee(Guid id)
        {
            var employee = Mapper.EmployeeToModel(await _context.Employee.FirstOrDefaultAsync(employee => employee.Id == id));

            return employee;
        }

        public async Task CreateEmployee(CreateEmployeeDto dto)
        {
            if (dto.Age is not null && !CheckAge(dto.Age))
            {
                throw new ArgumentException("Invalid age provided.");
            }

            var employee = new Employee()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Age = dto.Age,
            };

            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(UpdateEmployeeDto dto)
        {
            if (dto.Age is not null && !CheckAge(dto.Age))
            {
                throw new ArgumentException("Invalid age provided.");
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(employee => employee.Id == dto.Id);

            if (employee is null)
            {
                throw new Exception($"Employee with ID {dto.Id} not found.");
            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Gender = dto.Gender;
            employee.Age = dto.Age;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Guid id)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }


        public async Task<int> SetData(int count)
        {
            List<Employee> generatedEmployees = new();

            Random random = new Random();

            GenderEnum[] genders = Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>().ToArray();

            for (int i = 0; i < count; i++)
            {
                generatedEmployees.Add(new Employee
                {
                    FirstName = GenerateRandomString(random.Next(5, 15)),
                    LastName = GenerateRandomString(random.Next(8, 18)),
                    Gender = genders[random.Next(genders.Length)],
                    Age = random.Next(100),
                });
            }

            if (generatedEmployees.Any())
            {
                await _context.Set<Employee>().AddRangeAsync(generatedEmployees);
                await _context.SaveChangesAsync();
            }

            return generatedEmployees.Count();
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool CheckAge(int? age) => age > 0 && age <= 100;
    }
}
