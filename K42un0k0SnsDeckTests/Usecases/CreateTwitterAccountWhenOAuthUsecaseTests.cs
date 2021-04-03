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
            mockClient.Setup((client) => client.FetchCredentialsFromRedirectUrl(It.IsAny<Uri>())).Returns(new TwitterAccountCredentials("accesstoken","accesstokensecret"));
            var usecase = new CreateTwitterAccountWhenOAuthUsecase();
            usecase.twitterAccountRepository = mockRepository.Object;
            usecase.twitterClient = mockClient.Object;

            var redirectUrl = new Uri("https://localhost:8000/redirect_url?oauth_token=asd&oauth_verifier=aaaa");
            usecase.exec(redirectUrl);

            mockRepository.Verify((repository) => repository.Add(expect), Times.Once);
            mockClient.Verify((client) => client.FetchCredentialsFromRedirectUrl(redirectUrl), Times.Once);


        }
    }
}