using FluentValidation;
using GitNode.Application.Common.Interfaces;

namespace GitNode.Application.Common.Base
{
    public abstract class ValidatorBase<T> : AbstractValidator<T> where T : IPlatform
    {
        public ValidatorBase()
        {
            RuleFor(x => x.Platform)
                .Must(x => x.Equals("github") || x.Equals("bitbucket") || x.Equals("gitlab"))
                .WithMessage("Available platforms: github, bitbucket, gitlab");
        }
    }
}
