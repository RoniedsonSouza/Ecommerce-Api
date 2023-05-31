using Application.ADTO;
using Dapper;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class EventoRepository : Repository<Evento>
    {
        private readonly ApplicationDbContext _context;
        public EventoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ParticipantesEvento>> InsereParticipantes(List<ParticipantesEvento> participantes)
        {
            var participantesErro = new List<ParticipantesEvento>();

            foreach (var participante in participantes)
            {
                var participanteId = Guid.NewGuid();
                var sql = "INSERT INTO ParticipantesBatalha (IdParticipanteBatalha, IdBatalha, IdUsuario, Nome, Apelido, FotoParticipante, Tipo) VALUES (@IdParticipanteBatalha, @IdBatalha, @IdUsuario, @Nome, @Apelido, @FotoParticipante, @Tipo)";
                var adicionarParticipante = await _context.Connection.ExecuteAsync(sql, new
                {
                    IdParticipanteEvento = participanteId,
                    IdEvento = participante.IdEvento,
                    IdUsuario = participante.IdUsuario,
                    Nome = participante.Nome,
                    Apelido = participante.Apelido,
                    FotoParticipante = participante.FotoParticipante,
                    Tipo = participante.Tipo
                });

                if (adicionarParticipante == 0)
                {
                    participantesErro.Add(participante);
                }
            }

            if (participantesErro.Count > 0)
            {
                throw new InvalidOperationException("Erro ao adicionar participante(s): " + participantesErro);
            }

            return participantes;
        }
    }
}
