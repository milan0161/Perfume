using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeletePerfume
{
    public sealed class DeletePerfumeCommandHandler : IRequestHandler<DeletePerfumeCommand, Unit>
    {
        private readonly IDataContext _context;

        public DeletePerfumeCommandHandler(IDataContext context)
        {
            this._context = context;
        }

        public async Task<Unit> Handle(DeletePerfumeCommand request, CancellationToken cancellationToken)
        {
            var perfume = await _context.Perfumes.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(perfume is null)
            {
                throw new EntityNotFoundException($"Movie with the id: ${request.Id} was not found");
            }

            this._context.Perfumes.Remove(perfume);
            await this._context.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}
