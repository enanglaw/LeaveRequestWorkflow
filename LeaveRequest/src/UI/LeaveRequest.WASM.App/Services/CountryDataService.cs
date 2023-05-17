using LeaveRequest.Domain.Entity;
using System.Text.Json;

namespace LeaveRequest.WASM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
                await _httpClient.GetStreamAsync($"api/country"), options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountry(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>(
                await _httpClient.GetStreamAsync($"api/country/{countryId}"), options :new JsonSerializerOptions() { PropertyNameCaseInsensitive=true});
        }
    }
}
