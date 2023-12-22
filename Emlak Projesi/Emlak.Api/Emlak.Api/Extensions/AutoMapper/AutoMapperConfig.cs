using AutoMapper;
using Emlak.Api.Entity;
using Emlak.Api.Identity;
using Emlak.Api.Models;

namespace Emlak.Api.Extensions.AutoMapper
{
    public class AutoMapperConfig:Profile
    {

        public AutoMapperConfig()
        {

            // AutoMapper konfigürasyonu
            CreateMap<CreateRealEstateModel, RealEstate>().ReverseMap().ForAllOtherMembers(x => x.Ignore());


            CreateMap<UpdateRealEstateModel,RealEstate>().ReverseMap();

            CreateMap<CreateWorkPlaceModel,WorkPlace>().ReverseMap();
            CreateMap<UpdateWorkPlaceModel,WorkPlace>().ReverseMap();
            CreateMap<RegisterModel, User>().ReverseMap();
        }
    }
}
