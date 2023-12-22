using Emlak.Api.Entity;
using Emlak.Api.Models;

namespace Emlak.Api.Service
{
    public interface IRealEstateService
    {

        Task<IEnumerable<RealEstate>> GetAllAsync();
        Task<RealEstate> GetByIdAsync(int id);
        Task <RealEstate> CreateAsync(RealEstate entity);
        Task <RealEstate> UpdateAsync(RealEstate entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<RealEstate>> GetRealEstateByName(string? title, int? floor, int? rooms, string? color);

    }
}
