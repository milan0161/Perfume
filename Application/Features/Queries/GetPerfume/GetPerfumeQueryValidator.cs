using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetPerfume
{
    public class GetPerfumeQueryValidator : AbstractValidator<GetPerfumeQuery>
    {
        public GetPerfumeQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id can not be less than or equal to 0");
        }
    }
}
