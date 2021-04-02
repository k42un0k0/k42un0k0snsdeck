using Xunit;
using K42un0k0SnsDeck.DomainModels.TwitterAccount;

namespace K42un0k0SnsDeck.Models.Tests
{
    public class TwitterAccountTests
    {
        [Fact()]
        public void EqualsTest()
        {
            var v1 = new TwitterAccount(0, new TwitterAccountCredentials("hello","bbb"), "world");
            var v2 = new TwitterAccount(0, new TwitterAccountCredentials("hello","bbb"), "world");
            var v3 = new TwitterAccount(1, new TwitterAccountCredentials("hello","bbb"), "world");
            Assert.True(v1.Equals(v2));
            Assert.False(v1.Equals(v3));
        }
    }
}