using System.Collections.Generic;
using System.Threading;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Interfaces.Data.Database;
using GitNode.Application.Common.Interfaces.Data.ExternalAPIs;
using GitNode.Application.Platforms.Commands.AddAccount;
using GitNode.Domain.Entities;
using GitNode.Domain.Platforms;
using Moq;
using Xunit;
using PlatformModel = GitNode.Domain.Entities.Platform;

namespace Application.Tests.Integration.Platform.Commands
{
    public class AddAccountTests
    {
        private readonly Mock<ICurrentUserService> _currentUserService;
        private readonly Mock<IProcessorsProvider> _processorsProvider;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AddAccountTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _currentUserService = new Mock<ICurrentUserService>();
            _processorsProvider = new Mock<IProcessorsProvider>();
        }

        [Fact]
        public async void Handler_ShouldReturnProperData()
        {
            var command = new AddAccountExtendedCommand
            {
                Code = "code",
                Platform = "github"
            };

            _unitOfWork.Setup(x => x.Platforms.GetByNameAsync("github"))
                .ReturnsAsync(new PlatformModel
                {
                    Id = 1,
                    Name = "GitHub",
                    Accounts = new List<Account>()
                });

            _processorsProvider.Setup(x => x.Github.Users.GetTokenAsync("code"))
                .ReturnsAsync(new PlatformToken()
                {
                    AccessToken = "AccessToken"
                });
            
            _processorsProvider.Setup(x => x.Github.Users.GetUserAsync("AccessToken"))
                .ReturnsAsync(new PlatformUser()
                {
                    Id = "myId1",
                    Login = "MyLogin",
                    Name = "MyName",
                    Url = "https..."
                });
            
            _currentUserService.Setup(x => x.UserId).Returns("1234");
            
            _unitOfWork.Setup(x => x.Accounts.Add(new Account()));
            
            _unitOfWork.Setup(x => x.SaveChangesAsync());

            var handler = new AddAccountCommandHandler(_unitOfWork.Object,
                _currentUserService.Object, _processorsProvider.Object);

            var dto = await handler.Handle(command, new CancellationToken());
            
            Assert.Equal("MyLogin", dto.Login);
        }
    }
}