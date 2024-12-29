using AutoMapper;
using ControlBienes.Entities.General.Municipio;

namespace ControlBienes.Business.Features.General.Municipio
{
    public class BusMunicipioMapping : Profile
    {
        public BusMunicipioMapping()
        {
            CreateMap<EntMunicipio, EntMunicipioResponse>()
              .ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.iIdMunicipio))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));
        }
    }
}
