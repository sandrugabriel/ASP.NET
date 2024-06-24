using AutoMapper;
using MasiniApi.Cars.Dto;
using MasiniApi.Cars.Models;

namespace MasiniApi.Cars.Mappings
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {


            CreateMap<CreateCarRequest, Car>();
        }


    }
}
