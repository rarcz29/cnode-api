using FluentValidation;

namespace CNode.Application.GitHub.Commands.CreateRepository
{
    class CreateRepositoryCommandValidator : AbstractValidator<CreateRepositoryCommand>
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
