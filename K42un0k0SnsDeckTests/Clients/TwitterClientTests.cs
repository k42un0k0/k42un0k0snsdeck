using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using K42un0k0SnsDeck.Infra.HttpClient;

namespace K42un0k0SnsDeck.Clients.Tests
{
    [TestClass()]
    public class TwitterClientTests
    {
        private TwitterClient client = new TwitterClient();
        [TestMethod()]
        public void helloTest()
        {
            Assert.AreEqual("hello",client.hello());
        }
    }
}