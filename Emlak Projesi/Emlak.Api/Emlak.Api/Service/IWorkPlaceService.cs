using Emlak.Api.Entity;
using Emlak.Api.Models;

namespace Emlak.Api.Service
{
    public interface IWorkPlaceService
    {
        Task<IEnumerable<WorkPlace>> GetAllAsync();
        Task<WorkPlace> GetByIdAsync(int id);
        Task<WorkPlace> CreateAsync(CreateWorkPlaceModel model);
        Task<WorkPlace> UpdateAsync(UpdateWorkPlaceModel model);
        Task DeleteAsync(int id);

    }
}
