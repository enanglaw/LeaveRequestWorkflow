using LeaveRequest.Application.Profiles.ViewModels;
using LeaveRequest.Domain.Entity;
using AutoMapper;

namespace LeaveRequest.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeVm>().ReverseMap();
        }
    }
}
