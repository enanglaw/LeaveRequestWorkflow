using Microsoft.AspNetCore.Components;

namespace LeaveRequest.WASM.App.Components.EmployeeComponent
{
    public partial class EmployeeProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
