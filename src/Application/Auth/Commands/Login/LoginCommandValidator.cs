using FluentValidation;

namespace CNode.Application.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Email)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.Username));

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
