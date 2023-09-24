using Application.DTOs;
using Domain;
using MediatR;

namespace Application.Features.Queries.FilterPerfumes
{
    public record FilterPerfumeQuery(int PageSize, int PageNumber, PerfumeFilterDto? PerfumeFilter) : IRequest<List<Perfume>>;
   
}
