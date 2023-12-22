using Emlak.Api.Entity;

namespace Emlak.Api.Models
{
    public class CreateRealEstateModel:RealEstate
    {

        public IFormFile RealEstateImageUrl { get; set; }

    }
}
