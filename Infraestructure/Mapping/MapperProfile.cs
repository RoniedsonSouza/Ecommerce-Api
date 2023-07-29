using Application.ADTO;
using Application.ADTO.DtoRequests;
using Application.ADTO.DtoResponse;
using Application.Commands.Organizacoes;
using AutoMapper;

namespace Infraestructure.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Requests
            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<Usuario, LoginRequest>().ReverseMap();

            //Responses
            CreateMap<Organizacao, OrganizacaoResponse>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.LogoOrganizacao, opt => opt.MapFrom(src => src.LogoOrganizacao))
            .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Rua))
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Referencia, opt => opt.MapFrom(src => src.Referencia))
            .ForMember(dest => dest.Youtube, opt => opt.MapFrom(src => src.Youtube))
            .ForMember(dest => dest.Twitch, opt => opt.MapFrom(src => src.Twitch))
            .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
            .ForMember(dest => dest.Participantes, opt => opt.MapFrom(src => src.Participantes.Select(p => new ParticipantesOrganizacaoDTO { Id = p.Id, IdOrganizacao = p.IdOrganizacao, IdUsuarioParticipante = p.IdUsuarioParticipante }).ToList()));

            CreateMap<OrganizacaoResponse, Organizacao>()
            .ForMember(dest => dest.IdOrganizacao, opt => opt.Ignore())
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.LogoOrganizacao, opt => opt.MapFrom(src => src.LogoOrganizacao))
            .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Rua))
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Referencia, opt => opt.MapFrom(src => src.Referencia))
            .ForMember(dest => dest.Youtube, opt => opt.MapFrom(src => src.Youtube))
            .ForMember(dest => dest.Twitch, opt => opt.MapFrom(src => src.Twitch))
            .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
            .ForMember(dest => dest.Participantes, opt => opt.MapFrom(src => src.Participantes));

            //Commands
            CreateMap<AdicionarOrganizacaoCommand, Organizacao>()
            .ForMember(dest => dest.IdOrganizacao, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.LogoOrganizacao, opt => opt.MapFrom(src => src.LogoOrganizacao))
            .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Rua))
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
            .ForMember(dest => dest.Referencia, opt => opt.MapFrom(src => src.Referencia))
            .ForMember(dest => dest.LatLong, opt => opt.MapFrom(src => ""))
            .ForMember(dest => dest.Youtube, opt => opt.MapFrom(src => src.Youtube))
            .ForMember(dest => dest.Twitch, opt => opt.MapFrom(src => src.Twitch))
            .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ))
            .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.Participantes, opt => opt.MapFrom(src => src.Participantes.Select(p => new ParticipantesOrganizacao { IdUsuarioParticipante = p.IdUsuarioParticipante }).ToList()))
            .ForMember(dest => dest.Batalhas, opt => opt.Ignore());

            

        }
    }
}
