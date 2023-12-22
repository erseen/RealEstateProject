using Emlak.Api.Repository.Generic;

namespace Emlak.Api.Entity
{
    public class RealEstate:IEntity
    {

        //CreateAsync(RealEstateController'ı) migration attıktan sonra güncelle
        public int Id { get; set; }
       
        public string? Title { get; set; }
        public string? Desciption { get; set; }
        public string? Type { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public string? Color { get; set; }   
        public string? RealEstateImageUrl { get; set; }
        public string? Price { get; set; }

    }


}
