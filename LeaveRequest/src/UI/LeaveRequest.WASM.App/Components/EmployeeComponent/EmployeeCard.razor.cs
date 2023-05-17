using LeaveRequest.Domain.Entity;
using Microsoft.AspNetCore.Components;

namespace LeaveRequest.WASM.App.Components.EmployeeComponent
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee? Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee>  EmployeeQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(Employee.LastName))
            {
                throw new Exception("Last name can't be empty");
            }
        }

        public void NavigateToDetails(Employee selectedEmployee)
        {
            //we can write code here

            NavigationManager.NavigateTo($"/employeedetail/{selectedEmployee.EmployeeId}");
        }
    }
}
