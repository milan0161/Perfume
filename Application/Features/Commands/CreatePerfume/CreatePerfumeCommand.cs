using Application.DTOs;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CreatePerfume
{
    public record CreatePerfumeCommand(CreatePerfumeDto PerfumeCreate): IRequest<Perfume>;
    
}
