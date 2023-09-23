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

    }
}
