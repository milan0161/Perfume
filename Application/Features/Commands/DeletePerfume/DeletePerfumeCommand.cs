using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeletePerfume
{
    public record DeletePerfumeCommand(int Id) : IRequest<Unit>;
}
