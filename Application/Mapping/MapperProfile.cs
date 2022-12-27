using Application.ADTO;
using Application.ADTO.DtoRequests;
using AutoMapper;

namespace Ecommerce_api.Helpers
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
