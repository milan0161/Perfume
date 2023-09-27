using Application.DTOs;
using Application.Features.Commands.DeletePerfume;
using Application.Features.Commands.UpdatePerfume;
using Application.Features.Queries.FilterPerfumes;
using Application.Features.Queries.GetPerfume;
using Domain;
using MediatR;
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

        [HttpPost("update")]
        public async Task<ActionResult<Perfume>> UpdatePerfumeAsync(UpdatePerfumeDto updatePerfumeDto)
        {
            var updatePerfumeCommand = new UpdatePerfumeCommand(updatePerfumeDto);
            var perfume = await this._mediator.Send(updatePerfumeCommand);

            return Ok(perfume);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerfumeAsync([FromRoute] int id)
        {
            var deletePerfumeCommand = new DeletePerfumeCommand(id);
            await this._mediator.Send(deletePerfumeCommand);

            return NoContent();
        }
    }
}
