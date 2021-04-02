using K42un0k0SnsDeck.Constants;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeckTests
{
    public static class ConstantMock
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
    }
}
