using Application.ADTO;
using Application.Filters;
using Application.Interfaces.Repository;
using Dapper;

namespace Domain.Repositories
{
    public class BatalhaRepository : Repository<Batalha>, IBatalhaRepository
    {
        private readonly ApplicationDbContext _context;
        public BatalhaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ParticipantesBatalha>> InsereParticipantes(List<ParticipantesBatalha> participantes)
        {
            var participantesErro = new List<ParticipantesBatalha>();

            foreach (var participante in participantes)
            {
                var participanteId = Guid.NewGuid();
                var sql = "INSERT INTO ParticipantesBatalha (IdParticipanteBatalha, IdBatalha, IdUsuario, Nome, Apelido, FotoParticipante, Tipo, Ranking, Votos, Grupo, Posicao, Vencedor) VALUES (@IdParticipanteBatalha, @IdBatalha, @IdUsuario, @Nome, @Apelido, @FotoParticipante, @Tipo, @Ranking, @Votos, @Grupo, @Posicao, @Vencedor)";
                var adicionarParticipante = await _context.Connection.ExecuteAsync(sql, new
                {
                    IdParticipanteBatalha = participanteId,
                    IdBatalha = participante.IdBatalha,
                    IdUsuario = participante.IdUsuario,
                    Nome = participante.Nome,
                    Apelido = participante.Apelido,
                    FotoParticipante = participante.FotoParticipante,
                    Tipo = participante.Tipo,
                    Ranking = participante.Ranking,
                    Votos = participante.Votos,
                    Grupo = participante.Grupo,
                    Posicao = participante.Posicao,
                    Vencedor = participante.Vencedor
                });

                if (adicionarParticipante == 0)
                {
                    participantesErro.Add(participante);
                }
            }

            if (participantesErro.Count > 0)
            {
                throw new InvalidOperationException("Erro ao adicionar participantes " + participantesErro);
            }

            return participantes;
        }

        public async Task<List<Batalha>> GetBatalhasFilter(FilterBatalhaCommand filter)
        {
            var sql = @$"SELECT * FROM BATALHA WHERE 1 = 1 ";

            if (filter.DataBatalha.HasValue)
                sql += $"AND DataBatalha >= '${filter.DataBatalha}' ";

            var result = await _context.Connection.QueryAsync<Batalha>(sql);
            return result.ToList();
        }
    }

}
