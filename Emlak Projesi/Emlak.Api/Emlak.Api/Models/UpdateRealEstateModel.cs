using Emlak.Api.Entity;

namespace Emlak.Api.Models
{
    public class UpdateRealEstateModel : RealEstate
    {
        public IFormFile? RealEstateImageUrl { get; set; }
    }
}
