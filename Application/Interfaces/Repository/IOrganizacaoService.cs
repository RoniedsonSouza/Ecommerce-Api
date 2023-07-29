using Application.ADTO;
using Application.Commands.Filters;

namespace Application.Interfaces.Repository
{
    public interface IOrganizacaoService
    {
        Task<List<Organizacao>> ObterOrganizacoesUsuarioAsync(int idUsuarioOrganizacao);
        Task<List<Organizacao>> ObterOrganizacaoPorFiltro(FilterOrganizacaoCommand filter);
    }
}