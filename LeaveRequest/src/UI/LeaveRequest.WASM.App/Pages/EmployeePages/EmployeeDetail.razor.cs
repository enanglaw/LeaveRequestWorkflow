using LeaveRequest.Domain.Entity;
using LeaveRequest.WASM.App.Services;
using Microsoft.AspNetCore.Components;

namespace LeaveRequest.WASM.App.Pages.EmployeePages
{
    public partial class EmployeeDetail
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; } = default!;
        public Employee Employee { get; set; } = new Employee();
        [Parameter]
        public string EmployeeId { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
        }
    }
}
