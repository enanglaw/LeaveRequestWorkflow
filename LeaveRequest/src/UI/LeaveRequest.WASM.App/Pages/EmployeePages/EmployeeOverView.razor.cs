using LeaveRequest.Domain.Entity;
using LeaveRequest.WASM.App.Services;
using Microsoft.AspNetCore.Components;

namespace LeaveRequest.WASM.App.Pages.EmployeePages
{
    public partial class EmployeeOverView
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; } = default!;
          List<Employee>? Employees { get; set; } = default!;
          private string Title = "Employee OverView";

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetEmployees()).ToList();
        }



        private Employee? _selectedEmployee;



        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }

}
