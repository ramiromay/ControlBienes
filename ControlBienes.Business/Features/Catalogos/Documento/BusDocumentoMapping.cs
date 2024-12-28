using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Documento
{
    public class BusDocumentoMapping : Profile
    {
        public BusDocumentoMapping()
        {
            CreateMap<EntDocumento, EntDocumentoResponse>()
               .ForMember(dest => dest.IdDocumento, opt => opt.MapFrom(src => src.iIdDocumento))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Abreviacion, opt => opt.MapFrom(src => src.sAbreviacion))
               .ForMember(dest => dest.IdSubModulo, opt => opt.MapFrom(src => src.iIdSubModulo))
               .ForMember(dest => dest.SubModulo, opt => opt.MapFrom(src => src.SubModulo.sNombre))
               .ForMember(dest => dest.IdMotivoTramite, opt => opt.MapFrom(src => src.iIdMotivoTramite))
               .ForMember(dest => dest.MotivoTramite, opt => opt.MapFrom(src => src.MotivoTramite.sNombre))
               .ForMember(dest => dest.IdTipoTramite, opt => opt.MapFrom(src => src.iIdTipoTramite))
               .ForMember(dest => dest.TipoTramite, opt => opt.MapFrom(src => src.TipoTramite.sNombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntDocumentoRequest, EntDocumento>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sAbreviacion, opt => opt.MapFrom(src => src.Abreviacion))
               .ForMember(dest => dest.iIdSubModulo, opt => opt.MapFrom(src => src.IdSubModulo))
               .ForMember(dest => dest.iIdMotivoTramite, opt => opt.MapFrom(src => src.IdMotivoTramite))
               .ForMember(dest => dest.iIdTipoTramite, opt => opt.MapFrom(src => src.IdTipoTramite));
        }
    }
}
