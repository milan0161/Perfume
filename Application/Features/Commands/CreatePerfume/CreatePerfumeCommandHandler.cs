
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Commands.CreatePerfume
{
    public sealed class CreatePerfumeCommandHandler : IRequestHandler<CreatePerfumeCommand, Perfume>
    {
        private readonly IDataContext _context;

        public CreatePerfumeCommandHandler(IDataContext context)
        {
            this._context = context;
        }
        public async Task<Perfume> Handle(CreatePerfumeCommand request, CancellationToken cancellationToken)
        {
            var movie = request.PerfumeCreate.ToCreateMovie();

            this._context.Perfumes.Add(movie);
                        
            await this._context.SaveChangesAsync(cancellationToken);
            
            return movie;
            
        }
    }
}
