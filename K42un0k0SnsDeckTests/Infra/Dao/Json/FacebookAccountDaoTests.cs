using Xunit;
using System.Collections.Generic;
using K42un0k0SnsDeck.Infra.Dto.Json;
using K42un0k0SnsDeck.Infra.Provider;
using Moq;

namespace K42un0k0SnsDeck.Infra.Dao.Json.Tests
{
    public class FacebookAccountDaoTests
    {
        [Fact()]
        public void AddTest()
        {
            var mockJsonProvider = new Mock<IJsonProvider>();
            var newAccount = new FacebookAccountDto("0", "", "", 0, "");
            var list = new List<FacebookAccountDto>
            {
                new FacebookAccountDto("1", "", "",0, "")
            };

            mockJsonProvider.Setup((jsonProvider) => jsonProvider.Restore(It.IsAny<string>(), It.IsAny<List<FacebookAccountDto>>())).Returns(list);

            var dao = new FacebookAccountDao(() => mockJsonProvider.Object);

            dao.Add(newAccount);

            Assert.Equal(new List<FacebookAccountDto> { list[0], newAccount }, dao.FindAll());
        }

        [Fact()]
        public void FindAllTest()
        {
            var mockJsonProvider = new Mock<IJsonProvider>();
            var account1 = new FacebookAccountDto("1", "", "", 0, "");
            var list = new List<FacebookAccountDto>
            {
                account1
            };

            mockJsonProvider.Setup((jsonProvider) => jsonProvider.Restore(It.IsAny<string>(), It.IsAny<List<FacebookAccountDto>>()))
                .Returns(list);
            var dao = new FacebookAccountDao(() => mockJsonProvider.Object);

            Assert.Equal(list, dao.FindAll());

        }
    }
}