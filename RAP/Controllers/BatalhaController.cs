﻿using Application.Commands.Batalhas;
using Application.Commands.Filters;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RAP.Extensions;

namespace RAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatalhaController : RAPControllerBase
    {
        private readonly IBatalhaService _batalhaService;
        private readonly IMediator _mediator;
        public BatalhaController(IMediator mediator, IBatalhaService batalhaService)
        {
            _mediator = mediator;
            _batalhaService = batalhaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBatalhas([FromQuery] FilterBatalhaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatalhaById(Guid id)
        {
            var response = await _batalhaService.GetBatalhaById(id);
            return Ok(response);
        }

        [HttpPost("CriarBatalha")]
        public async Task<IActionResult> CriarBatalha(AdicionarBatalhaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("EditarBatalha")]
        public async Task<IActionResult> EditarBatalha(EditarBatalhaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("ExcluirBatalha")]
        public async Task<IActionResult> ExcluirBatalha(Guid idBatalha)
        {
            var batalhaExiste = await _batalhaService.GetBatalhaById(idBatalha);
            return batalhaExiste != null ? Ok(new { Message = "Batalha excluida com sucesso!" }) : BadRequest();
        }
    }
}
