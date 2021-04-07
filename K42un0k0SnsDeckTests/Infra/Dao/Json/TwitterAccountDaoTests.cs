using Xunit;
using System.Collections.Generic;
using Moq;
using K42un0k0SnsDeck.Infra.Provider;
using K42un0k0SnsDeck.Infra.Dto.Json;
using K42un0k0SnsDeck.Infra.Dao.Json;

namespace K42un0k0SnsDeckTests.Infra.Dao.Json
{
    public class TwitterAccountDaoTests
    {
        [Fact()]
        public void AddTest()
        {
            var mockJsonProvider = new Mock<IJsonProvider>();
            var newAccount = new TwitterAccountDto(0, "", "", "");
            var list = new List<TwitterAccountDto>
            {
                new TwitterAccountDto(1, "", "", "")
            };

            mockJsonProvider.Setup((jsonProvider) => jsonProvider.Restore(It.IsAny<string>(), It.IsAny<List<TwitterAccountDto>>())).Returns(list);

            var dao = new TwitterAccountDao(() => mockJsonProvider.Object);

            dao.Add(newAccount);

            Assert.Equal(new List<TwitterAccountDto> { list[0], newAccount }, dao.FindAll());
        }

        [Fact()]
        public void FindAllTest()
        {
            var mockJsonProvider = new Mock<IJsonProvider>();
            var account1 = new TwitterAccountDto(1, "", "", "");
            var list = new List<TwitterAccountDto>
            {
                account1
            };

            mockJsonProvider.Setup((jsonProvider) => jsonProvider.Restore(It.IsAny<string>(), It.IsAny<List<TwitterAccountDto>>()))
                .Returns(list);
            var dao = new TwitterAccountDao(() => mockJsonProvider.Object);

            Assert.Equal(list, dao.FindAll());

        }
    }
}