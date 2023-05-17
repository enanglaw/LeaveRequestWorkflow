using LeaveRequest.Application.Contracts.Persistence;
using LeaveRequest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Persistence.Repositories
{
    public class CountryRepository:BaseAsyncRepository<Country>, ICountryRepository
    {
        public CountryRepository(LeaveRequestDbContext context):base(context)
        {
            
        }
    }
}
