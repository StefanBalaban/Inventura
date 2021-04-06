using AutoMapper;
using Inventura.ApplicationCore.Entities;
using Inventura.PublicApi.Util.FoodProductEndpoints;

namespace Inventura.PublicApi.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodProduct, FoodProductDto>();
        }
    }
}