using FluentValidation;


namespace Application.Features.Commands.CreatePerfume
{
    public sealed class CreatePerfumeCommandValidator : AbstractValidator<CreatePerfumeCommand>
    {
        public CreatePerfumeCommandValidator()
        {
            RuleFor(x => x.PerfumeCreate.name)
                .NotEmpty()
                .WithMessage("Perfume name must be provided");

            RuleFor(x => x.PerfumeCreate.brand)
                .NotEmpty()
                .WithMessage("Perfume brand must be provided");

            RuleFor(x => x.PerfumeCreate.volume)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Perfume volume must be provided");
            RuleFor(x => x.PerfumeCreate.imageUrl)
                .NotEmpty()
                .WithMessage("Image url must be provided");
        }
    }
}
