using Application.ADTO;
using Application.ADTO.DtoRequests;
using AutoMapper;

namespace Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Requests
            CreateMap<Usuario, UsuarioRequest>().ReverseMap();
            CreateMap<Usuario, LoginRequest>().ReverseMap();
        }
    }
}
