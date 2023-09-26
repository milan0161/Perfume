using Application.DTOs;
using Domain;
using MediatR;


namespace Application.Features.Commands.UpdatePerfume
{
    public record UpdatePerfumeCommand(UpdatePerfumeDto PerfumeUpdate) : IRequest<Perfume>;
    
}
