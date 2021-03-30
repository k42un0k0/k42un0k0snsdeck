using Xunit;
using K42un0k0SnsDeck.Infra.Dao.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using K42un0k0SnsDeck.Infra.Provider;
using K42un0k0SnsDeck.Models;
using K42un0k0SnsDeck.Infra.Dto.Json;

namespace K42un0k0SnsDeck.Infra.Dao.Json.Tests
{
    public class TwitterAccountDaoTests
    {
        private readonly Mock<IJsonProvider> mockJsonProvider = new Mock<IJsonProvider>();
        private readonly TwitterAccountDao dao;
        public TwitterAccountDaoTests()
        {
        }
        [Fact()]
        public void AddTest()
        {
            var mockJsonProvider = new Mock<IJsonProvider>();
            var newAccount = new TwitterAccountDto(0, "", "");
            var list = new List<TwitterAccountDto>
            {
                new TwitterAccountDto(1, "", "")
            };

            mockJsonProvider.Setup((jsonProvider) => jsonProvider.Restore<List<TwitterAccountDto>>(It.IsAny<string>())).Returns(list);

            var dao = new TwitterAccountDao(() => mockJsonProvider.Object);

            dao.Add(newAccount);

            Assert.Equal(new List<TwitterAccountDto> { list[0], newAccount }, dao.FindAll());
        }

        [Fact()]
        public void FindAllTest()
        {
            var mockJsonProvider = new Mock<IJsonProvider>();
            var account1 = new TwitterAccountDto(1, "", "");
            var list = new List<TwitterAccountDto>
            {
                account1
            };

            mockJsonProvider.Setup((jsonProvider) => jsonProvider.Restore<List<TwitterAccountDto>>(It.IsAny<string>()))
                .Returns(list);
            var dao = new TwitterAccountDao(() => mockJsonProvider.Object);

            Assert.Equal(list, dao.FindAll());

        }
    }
}