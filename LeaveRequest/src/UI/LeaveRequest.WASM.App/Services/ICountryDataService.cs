using LeaveRequest.Domain.Entity;

namespace LeaveRequest.WASM.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int countryId);
    }
}
