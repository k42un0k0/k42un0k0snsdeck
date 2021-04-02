using K42un0k0SnsDeck.Constants;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace K42un0k0SnsDeckTests.TestUtil
{
    public static class MockUtil
    {
        public static Mock<AppConfig> mockAppConfig()
        {
            var mockAppConfig = new Mock<AppConfig>();
            AppConfig.Singleton = mockAppConfig.Object;
            mockAppConfig.SetupGet((appConfig) => appConfig.TwitterApiKey).Returns("ULoMphmQLJ1gVY0q64Vp55UCc");
            mockAppConfig.SetupGet((appConfig) => appConfig.TwitterApiSecretKey).Returns("KwSTYBjLA9TksqF0pgozHvvJToXoJLkEDV3HgYMcG5v1JnHIul");
            mockAppConfig.SetupGet((appConfig) => appConfig.TwitterCallbackUrl).Returns("https://localhost:8000");
            return mockAppConfig;
        }

        public static HttpClient mockResponseText(string responseText)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseText),
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            return new HttpClient(handlerMock.Object);

        }
    }
}
