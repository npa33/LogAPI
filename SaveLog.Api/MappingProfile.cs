using AutoMapper;
using SaveLog.Api.DTOs;
using SaveLog.Api.Entities;

namespace SaveLog.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RectifierLogEntry, RectifierLogEntryDto>().ReverseMap();
        }
    }
}
