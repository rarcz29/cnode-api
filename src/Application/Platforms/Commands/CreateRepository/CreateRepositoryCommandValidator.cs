using CNode.Application.Common.Base;
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
