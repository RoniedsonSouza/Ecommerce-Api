using Application.ADTO;
using Application.ADTO.DtoRequests;
using Application.ADTO.DtoResponse;
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
            CreateMap<Produto, AdicionarProdutoRequest>().ReverseMap();

            //Responses
            CreateMap<Produto, AdicionarProdutoResponse>();
        }
    }
}
