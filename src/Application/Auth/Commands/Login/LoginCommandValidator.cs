using FluentValidation;

namespace GitNode.Application.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
