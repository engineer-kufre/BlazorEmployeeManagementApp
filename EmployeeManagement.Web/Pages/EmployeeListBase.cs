using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public bool ShowFooter { get; set; } = true;

        public IEnumerable<Employee> Employees { get; set; }

        protected int SelectedEmployeesCount { get; set; } = 0;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.Employees = (await this.EmployeeService.GetEmployees()).ToList();
                StateHasChanged();
            }
        }

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            SelectedEmployeesCount = isSelected ? SelectedEmployeesCount + 1 : SelectedEmployeesCount - 1;
        }
    }
}
