using Xunit;
using K42un0k0SnsDeck.Usecases;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using K42un0k0SnsDeck.DomainServices;
using K42un0k0SnsDeck.DomainModels.TwitterAccount;
using K42un0k0SnsDeck.Infra.Http;

namespace K42un0k0SnsDeck.Usecases.Tests
{
    public class CreateTwitterAccountWhenOAuthUsecaseTests
    {
        [Fact()]
        public void execTest()
        {
            var expect = new TwitterAccount(0, new TwitterAccountCredentials("accesstoken", "accesstokensecret"), "accountname");
            var mockRepository = new Mock<ITwitterAccountRepository>();
            mockRepository.Setup((repository) => repository.Add(It.IsAny<TwitterAccount>()));
            var mockClient = new Mock<ITwitterClient>();
            mockClient.Setup((client) => client.GetAccountName(It.IsAny<TwitterAccountCredentials>())).Returns("accountname");
            var command = new CreateAcountWhenOAuthCommand("accesstoken", "accesstokensecret");
            var usecase = new CreateTwitterAccountWhenOAuthUsecase();
            usecase.twitterAccountRepository = mockRepository.Object;
            usecase.twitterClient = mockClient.Object;

            usecase.exec(command);

            mockRepository.Verify((repository) => repository.Add(expect), Times.Once);

        }
    }
}