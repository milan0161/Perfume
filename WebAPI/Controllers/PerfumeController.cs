﻿using Application.DTOs;
using Application.Features.Commands.CreatePerfume;
using Application.Features.Queries.FilterPerfumes;
using Application.Features.Queries.GetPerfume;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PerfumeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perfume>> GetPerfumeAsync([FromRoute] int id)
        {
            var getPerfumeQuery = new GetPerfumeQuery(id);

            Perfume? perfume = await _mediator.Send(getPerfumeQuery);

            if (perfume is not null)
            {
                return Ok(perfume); 
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<List<Perfume>>> GetPerfumesAsync(
            [FromBody] PerfumeFilterDto? perfumeFilter,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageNumber = 1            
            )
        {
            var getPerfumesQuery = new FilterPerfumeQuery(pageSize, pageNumber, perfumeFilter);
            var perfumes = await this._mediator.Send(getPerfumesQuery);

            return Ok(perfumes);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Perfume>> CreatePerfumeAsync([FromBody] CreatePerfumeDto createPerfumeDto)
        {
            var createPerfumeCommand = new CreatePerfumeCommand(createPerfumeDto);
            var perfume = await this._mediator.Send(createPerfumeCommand);

            return Ok(perfume);
        }

    }
}
