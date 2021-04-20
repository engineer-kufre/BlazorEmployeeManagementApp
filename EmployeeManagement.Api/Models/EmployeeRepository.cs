using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                // employee not found implementation
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
