using FluentValidation;
using GitNode.Application.Common.Base;

namespace GitNode.Application.Platforms.Commands.AddAccount
{
    public class AddAccountCommandValidator : ValidatorBase<AddAccountExtendedCommand>
    {
        public AddAccountCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty();
        }
    }
}
