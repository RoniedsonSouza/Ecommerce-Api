using Application.ADTO;
using Application.Interfaces.Repository;
using Dapper;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class ParticipanteOrganizacaoRepository : Repository<ParticipantesOrganizacao>, IParticipantesOrganizacaoRepository
    {
        private readonly ApplicationDbContext _context;
        public ParticipanteOrganizacaoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Organizacao> GetOrganizacaoDoParticipante(int idUsuario)
        {
            var organizacao = new Organizacao();
            var participante = await _context.Connection.QuerySingleAsync<ParticipantesOrganizacao>(@$"SELECT * FROM ParticipantesOrganizacao WHERE IDUSUARIOPARTICIPANTE = @UsuarioParticipante", new
            {
                UsuarioParticipante = idUsuario
            });

            if (participante != null)
            {
                organizacao = await _context.Connection.QuerySingleAsync<Organizacao>(@$"SELECT * FROM Organizacao WHERE IdOrganizacao = @IdOrganizacao", new
                {
                    participante.IdOrganizacao,
                });

                return organizacao;
            }

            return organizacao;
        }
    }
}
