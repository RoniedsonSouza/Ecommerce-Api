using Application.ADTO;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BatalhaService : IBatalhaService
    {
        private readonly IBatalhaRepository _batalhaRepository;
        public BatalhaService(IBatalhaRepository batalhaRepository)
        {
            _batalhaRepository = batalhaRepository;
        }

        public async Task<Batalha> GetBatalhaById(Guid id)
        {
            return await _batalhaRepository.GetById(id);
        }
    }
}
