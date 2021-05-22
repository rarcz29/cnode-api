using CNode.Application.Common.Validation;
using FluentValidation;

namespace CNode.Application.Platforms.Commands.CreateRepository
{
    public class CreateRepositoryCommandValidator : ValidatorBase<CreateRepositoryCommand>
    {
        public CreateRepositoryCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.RepoName)
                .NotEmpty();
        }
    }
}
