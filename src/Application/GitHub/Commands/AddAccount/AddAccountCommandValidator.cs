using FluentValidation;

namespace CNode.Application.GitHub.Commands.AddAccount
{
    public class AddAccountCommandValidator : AbstractValidator<AddAccountCommand>
    {
        public AddAccountCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty();
        }
    }
}
