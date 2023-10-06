using FluentValidation;
using MediatR;

namespace Application.Validation
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            this._validators = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validationResult = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .ToList();

            if(validationResult.Any())
            {
                throw new ValidationException(validationResult);
            }

            return await next();
        }
    }
}
