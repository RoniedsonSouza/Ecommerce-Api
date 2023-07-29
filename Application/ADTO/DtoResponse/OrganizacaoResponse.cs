﻿using Application.ADTO.DtoRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ADTO.DtoResponse
{
    public class OrganizacaoResponse
    {
        public string? Nome { get; set; }
        public byte[]? LogoOrganizacao { get; set; }
        public string? Rua { get; set; }
        public string? Cep { get; set; }
        public string? Referencia { get; set; }
        public string? Youtube { get; set; }
        public string? Twitch { get; set; }
        public string? CNPJ { get; set; }
        public virtual List<ParticipantesOrganizacaoDTO> Participantes { get; set; } = new List<ParticipantesOrganizacaoDTO>();
    }
}