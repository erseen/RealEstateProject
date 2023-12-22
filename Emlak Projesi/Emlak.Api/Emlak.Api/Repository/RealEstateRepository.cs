using Emlak.Api.Entity;
using Emlak.Api.Identity;
using Emlak.Api.Repository.Generic;

namespace Emlak.Api.Repository
{
    public class RealEstateRepository: GenericRepository<RealEstate>,IRealEstateRepository
    {

        public RealEstateRepository(ApplicationContext dbContext):base(dbContext) 
        {
            
        }
    }
}
