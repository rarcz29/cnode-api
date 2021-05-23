using CNode.Application.Common.Base;
using FluentValidation;

namespace CNode.Application.Platforms.Commands.AddAccount
{
    public class AddAccountCommandValidator : ValidatorBase<AddAccountCommand>
    {
        public AddAccountCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty();
        }
    }
}
