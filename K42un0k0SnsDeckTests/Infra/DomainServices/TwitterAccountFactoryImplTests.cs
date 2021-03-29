using Xunit;
using K42un0k0SnsDeck.Infra.HttpClient;
using Moq;
using K42un0k0SnsDeck.Models;

namespace K42un0k0SnsDeck.Infra.DomainServices.Tests
{
    public class TwitterAccountFactoryImplTests
    {

        public TwitterAccountFactoryImplTests()
        {
        }

        [Fact]
        public void CreateFromRedirectUriTest()
        {
            var expectId = 0;
            var expectAccessToken = "asdf1230jkl";
            var expectAccountName = "hello";

            var uri = new System.Uri("https://google.com?access_token="+ expectAccessToken);
            var mockClient = new Mock<ITwitterClient>();
            mockClient.Setup(client => client.GetAccountName())
                .Returns("hello");
            mockClient.Setup(client => client.ConfigureFromRedirectUrl(uri));

            var obj = new TwitterAccountFactoryImpl(() => mockClient.Object);
            var account = obj.CreateFromRedirectUri(uri);

            mockClient.Verify((client) => client.ConfigureFromRedirectUrl(uri), Times.AtMostOnce());
            mockClient.Verify((client) => client.GetAccountName(), Times.AtMostOnce());

            Assert.Equal(expectId, account.Id);
            Assert.Equal(expectAccessToken,account.AccessToken);
            Assert.Equal(expectAccountName, account.AccountName);

        }
    }
}