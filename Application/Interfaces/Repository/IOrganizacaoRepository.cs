using Application.ADTO;
using Application.Commands.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IOrganizacaoRepository : IRepository<Organizacao>
    {
        Task<List<Organizacao>> GetOrganizacaoByUsuario(int idUsuarioOrganizacao);
        Task<List<Organizacao>> GetOrganizacaoFilter(FilterOrganizacaoCommand filter);
    }
}
