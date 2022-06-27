using Application.ADTO;
using Application.ADTO.DtoRequests;
using Application.ADTO.DtoResponse;
using Application.Helpers;
using MediatR;


namespace Application.Produtos
{
    public class AdicionarProdutoCommand : IRequest<Result<AdicionarProdutoResponse>>
    {
        public AdicionarProdutoRequest Request;

        public AdicionarProdutoCommand(AdicionarProdutoRequest request)
        {
            Request = request;
        }
    }
}
