using Application.ADTO;
using Application.Commands.Filters;
using Application.Interfaces.Repository;

namespace Domain.Services
{
    public class OrganizacaoService : IOrganizacaoService
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        public OrganizacaoService(IOrganizacaoRepository organizacaoRepository)
        {
            _organizacaoRepository = organizacaoRepository;
        }

        public async Task<List<Organizacao>> ObterOrganizacoesUsuarioAsync(int idUsuarioOrganizacao) => await _organizacaoRepository.GetOrganizacaoByUsuario(idUsuarioOrganizacao);

        public async Task<List<Organizacao>> ObterOrganizacaoPorFiltro(FilterOrganizacaoCommand filter) => await _organizacaoRepository.GetOrganizacaoFilter(filter);
    }
}
