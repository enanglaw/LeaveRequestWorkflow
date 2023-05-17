using LeaveRequest.Domain.Entity;
using System.Text;
using System.Text.Json;

namespace LeaveRequest.WASM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<JobCategory> GetCategory(int jobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>(await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
        }

        public async Task<IEnumerable<JobCategory>> GetJobCategories()
        {

            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(await _httpClient.GetStreamAsync($"api/jobcategory"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
