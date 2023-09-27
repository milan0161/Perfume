using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Commands.UpdatePerfume
{
    public sealed class UpdatePerfumeCommandHandler : IRequestHandler<UpdatePerfumeCommand, Perfume>
    {
        private readonly IDataContext _context;

        public UpdatePerfumeCommandHandler(IDataContext context)
        {
            this._context = context;
        }
        public async Task<Perfume> Handle(UpdatePerfumeCommand request, CancellationToken cancellationToken)
        {
            var perfume = await this._context.Perfumes.SingleOrDefaultAsync(x => x.Id == request.PerfumeUpdate.Id, cancellationToken);

            if(perfume is null)
            {
                throw new EntityNotFoundException();
            }

            perfume = request.PerfumeUpdate.ToUpdatePerfume(perfume);
            this._context.Perfumes.Update(perfume);

            await this._context.SaveChangesAsync(cancellationToken);

            return perfume;
        
        }
    }
}
