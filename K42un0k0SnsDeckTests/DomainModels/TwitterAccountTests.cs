using Xunit;
using K42un0k0SnsDeck.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace K42un0k0SnsDeck.Models.Tests
{
    public class TwitterAccountTests
    {
        [Fact()]
        public void EqualsTest()
        {
            var v1 = new TwitterAccount(0, "hello", "world");
            var v2 = new TwitterAccount(0, "hello", "world");
            var v3 = new TwitterAccount(1, "hello", "world");
            Assert.True(v1.Equals(v2));
            Assert.False(v1.Equals(v3));
        }
    }
}