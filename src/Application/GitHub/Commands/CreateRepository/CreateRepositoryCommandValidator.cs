using FluentValidation;

namespace CNode.Application.GitHub.Commands.CreateRepository
{
    public class CreateRepositoryCommandValidator : AbstractValidator<CreateRepositoryCommand>
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
