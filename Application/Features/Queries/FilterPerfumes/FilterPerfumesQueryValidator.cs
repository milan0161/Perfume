using FluentValidation;

namespace Application.Features.Queries.FilterPerfumes
{
    public class FilterPerfumesQueryValidator : AbstractValidator<FilterPerfumeQuery>
    {
        public FilterPerfumesQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0)
                .WithMessage("Page number mumst be greater then 0");
            RuleFor(x => x.PageSize).GreaterThan(0)
                .WithMessage("Page size must be greater than 0");
        }
    }
}
