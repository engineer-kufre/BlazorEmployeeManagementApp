using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Department GetDepartment(int departmentId)
        {
            return _context.Departments
                .FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments;
        }
    }
}
