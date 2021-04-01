﻿using Xunit;
using Moq;
using K42un0k0SnsDeck.Infra.Dao.Json;
using K42un0k0SnsDeck.Models;
using System.Collections.Generic;
using K42un0k0SnsDeck.Infra.Dto.Json;

namespace K42un0k0SnsDeck.Infra.DomainServices.Tests
{
    public class TwitterAccountRepositoryTests
    {
        [Fact()]
        public void AddTest()
        {
            var mockDao = new Mock<ITwitterAccountDao>();
            var repository = new TwitterAccountRepository(() => mockDao.Object);
            var newAccount = new TwitterAccount(0, "hello", "world");
            repository.Add(newAccount);

            mockDao.Verify((dao) => dao.Add(It.IsAny<TwitterAccountDto>()), Times.Once());
        }

        [Fact()]
        public void FindAllTest()
        {
            var mockDao = new Mock<ITwitterAccountDao>();
            var list = new List<TwitterAccountDto>
            {
                new TwitterAccountDto(1,"hello","world"),
                new TwitterAccountDto(1,"sample","account"),
            };

            mockDao.Setup((dao) => dao.FindAll()).Returns(list);
            var repository = new TwitterAccountRepository(() => mockDao.Object);

            var actual = repository.FindAll();
            Assert.IsType<List<TwitterAccount>>(actual);

            var index = 0;
            actual.ForEach((item) =>
            {
                Assert.Equal<TwitterAccount>(list[index], item);
                index++;
            });
        }
    }
}