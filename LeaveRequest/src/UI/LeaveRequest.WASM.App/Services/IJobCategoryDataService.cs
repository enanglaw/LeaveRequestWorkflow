using LeaveRequest.Domain.Entity;

namespace LeaveRequest.WASM.App.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetJobCategories();
        Task<JobCategory> GetCategory(int jobCategoryId);
    }
}
