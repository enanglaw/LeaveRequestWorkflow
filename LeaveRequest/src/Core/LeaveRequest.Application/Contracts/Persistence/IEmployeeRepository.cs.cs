using LeaveRequest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Application.Contracts.Persistence
{
    public interface IEmployeeRepository:IBaseAsyncRepository<Employee>
    {
    }
}
