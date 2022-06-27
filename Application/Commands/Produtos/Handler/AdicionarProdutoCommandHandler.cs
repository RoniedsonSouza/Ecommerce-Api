using Application.ADTO;
using Application.ADTO.DtoResponse;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Produtos.Handler
{
    public class AdicionarProdutoCommandHandler : IRequestHandler<AdicionarProdutoCommand, Result<AdicionarProdutoResponse>>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public AdicionarProdutoCommandHandler(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<AdicionarProdutoResponse>> Handle(AdicionarProdutoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<AdicionarProdutoResponse>();

                var produto = _mapper.Map<Produto>(command.Request);
                var produtoNew = await _repository.Insert(produto);
                result.Value = _mapper.Map<AdicionarProdutoResponse>(produtoNew);

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
