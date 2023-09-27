using FluentValidation;

namespace Application.Features.Commands.DeletePerfume
{
    public class DeletePerfumeCommandValidator : AbstractValidator<DeletePerfumeCommand>
    {
        public DeletePerfumeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater then 0");
        }
    }
}
