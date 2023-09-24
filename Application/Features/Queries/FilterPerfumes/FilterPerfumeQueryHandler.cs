using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.FilterPerfumes
{
    public sealed class FilterPerfumeQueryHandler : IRequestHandler<FilterPerfumeQuery, List<Perfume>>
    {
        private readonly IDataContext _context;
        public FilterPerfumeQueryHandler(IDataContext context)
        {
            this._context = context;   
        }
        public async Task<List<Perfume>> Handle(FilterPerfumeQuery request, CancellationToken cancellationToken)
        {
            var perfume = this._context.Perfumes.AsQueryable();

            if(request.PerfumeFilter!.Brand is not null)
            {
                perfume = perfume.Where(x => x.Brand == request.PerfumeFilter!.Brand);
            }

            if(request.PerfumeFilter!.Scent is not null)
            {
                perfume = perfume.Where(x => x.Scent ==  request.PerfumeFilter!.Scent);
            }

            return await perfume
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
