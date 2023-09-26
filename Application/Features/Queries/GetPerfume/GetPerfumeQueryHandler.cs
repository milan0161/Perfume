using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GetPerfume
{
    public class GetPerfumeQueryHandler : IRequestHandler<GetPerfumeQuery, Perfume?>
    {
        private readonly IDataContext _context;

        public GetPerfumeQueryHandler(IDataContext context)
        {
            this._context = context;
        }

        public async Task<Perfume?> Handle(GetPerfumeQuery request, CancellationToken cancellationToken)
        {
            Perfume? perfume;

            try
            {
                 perfume = await _context.Perfumes.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    
                 return perfume;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("This shouldn't be happening", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new EntityNotFoundException("Perfume not found", ex);
            }
        }
    }
}
