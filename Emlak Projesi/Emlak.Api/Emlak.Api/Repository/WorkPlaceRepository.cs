using Emlak.Api.Entity;
using Emlak.Api.Identity;
using Emlak.Api.Repository.Generic;

namespace Emlak.Api.Repository
{
    public class WorkPlaceRepository: GenericRepository<WorkPlace>, IWorkPlaceRepository
    {
        public WorkPlaceRepository(ApplicationContext dbContext):base(dbContext) 
        {
            
        }
    }
}
