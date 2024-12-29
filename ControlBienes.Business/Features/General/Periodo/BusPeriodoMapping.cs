using AutoMapper;
using ControlBienes.Entities.General.Periodo;

namespace ControlBienes.Business.Features.General.Periodo
{
    public class BusPeriodoMapping : Profile
    {
        public BusPeriodoMapping()
        {
            CreateMap<EntPeriodo, EntPeriodoResponse>()
              .ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
              .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.dtFechaInicio))
              .ForMember(dest => dest.FechaFinal, opt => opt.MapFrom(src => src.dtFechaFinal));
        }
    }
}
