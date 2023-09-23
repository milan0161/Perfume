using Domain;
using MediatR;

namespace Application.Features.Queries.GetPerfume
{
    public record GetPerfumeQuery(int Id) : IRequest<Perfume?>;
    
}
