using AutoMapper;
using DTOLayer.DTOs.KartDTOs;
using DTOLayer.DTOs.ListeDTOs;
using EntityLayer.Concrete;
using System.Net.Sockets;

namespace TrelloDemoAPI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile() {

            CreateMap<ListeAddDTO, Liste>();
            CreateMap<Liste, ListeAddDTO>();
            CreateMap<ListeUpdateDTO, Liste>();
            CreateMap<Liste, ListeUpdateDTO>();

            CreateMap<KartAddDTO, Kart>();
            CreateMap<Kart, KartAddDTO>();
            CreateMap<KartUpdateDTO, Kart>();
            CreateMap<Kart, KartUpdateDTO>();

        }
    }
}
