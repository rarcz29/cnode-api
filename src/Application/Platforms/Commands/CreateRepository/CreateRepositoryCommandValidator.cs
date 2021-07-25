using FluentValidation;
using GitNode.Application.Common.Base;

namespace GitNode.Application.Platforms.Commands.CreateRepository
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
