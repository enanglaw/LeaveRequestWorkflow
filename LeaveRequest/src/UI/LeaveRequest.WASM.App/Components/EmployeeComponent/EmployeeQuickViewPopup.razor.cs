using LeaveRequest.Domain.Entity;
using Microsoft.AspNetCore.Components;

namespace LeaveRequest.WASM.App.Components.EmployeeComponent
{
    public partial class EmployeeQuickViewPopup
    {


        [Parameter]
        public Employee? Employee { get; set; }

        private Employee? _employee;

        protected override void OnParametersSet()
        {
            _employee = Employee;

        }

        public void Close()
        {
            _employee = null;
        }
    }
}
