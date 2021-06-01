using FluentValidation;

namespace CNode.Application.Auth.Commands.Refresh
{
    public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
    {
        public RefreshCommandValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty();

            RuleFor(x => x.RefreshToken)
                .NotEmpty();
        }
    }
}
