using AutoMapper;
using KoudWS.Models.DTOs;
using KoudWS.Models.Entities;

namespace KoudWS.Mapper
{
    public class TvShowProfile : Profile
    {
        public TvShowProfile()
        {
            CreateMap<TvShowEntity, TvShowDTO>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID_tvshow))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name_tvshow))
            .ForMember(dest => dest.Favorite, opt => opt.MapFrom(src => src.Favorite_tvshow));
        }
    }
}