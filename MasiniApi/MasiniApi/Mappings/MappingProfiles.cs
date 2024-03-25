using AutoMapper;
using MasiniApi.Dto;
using MasiniApi.Models;

namespace MasiniApi.Mappings
{
    public class MappingProfiles:Profile
    {

        public MappingProfiles() {


            CreateMap<CreateCarRequest, Masini>();
        }


    }
}
