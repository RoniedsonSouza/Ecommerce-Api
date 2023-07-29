using Application.ADTO;
using Application.Commands.Filters;
using Application.Interfaces.Repository;
using Dapper;
using Domain.Validadores;

namespace Infraestructure.Repositories
{
    public class OrganizacaoRepository : Repository<Organizacao>, IOrganizacaoRepository
    {
        private readonly ApplicationDbContext _context;
        private string Campos = " [Nome],[LogoOrganizacao],[Rua],[Numero],[Cep],[Referencia],[LatLong],[Youtube],[Twitch],[CNPJ],[Likes] ";
        public OrganizacaoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Organizacao>> GetOrganizacaoByUsuario(int idUsuarioOrganizacao)
        {
            var sql = $@"SELECT ORG.* FROM ORGANIZACAO ORG 
                        JOIN PARTICIPANTESORGANIZACAO PORG ON ORG.IdOrganizacao = PORG.IdOrganizacao 
                        WHERE PORG.IdUsuarioParticipante = {idUsuarioOrganizacao}";
            var result = await _context.Connection.QueryAsync<Organizacao>(sql);
            return result.ToList();
        }

        public async Task<List<Organizacao>> GetOrganizacaoFilter(FilterOrganizacaoCommand filter)
        {
            var sql = @$"SELECT {Campos} FROM Organizacao WHERE 1 = 1 ";

            if (!filter.Nome.EhNuloOuVazio())
                sql += $"AND Nome = '${filter.Nome}' ";
            if (!filter.CNPJ.EhNuloOuVazio())
                sql += $"AND CNPJ = '${filter.CNPJ}' ";

            var result = await _context.Connection.QueryAsync<Organizacao>(sql);
            return result.ToList();
        }
    }
}
