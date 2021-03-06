using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using K42un0k0SnsDeckTests.TestUtil;

namespace K42un0k0SnsDeck.Infra.Provider.Tests
{
    public class JsonProviderTests
    {
        [Fact()]
        public void JsonProviderTest()
        {
            using var file = new TemporaryFile();
            File.WriteAllText(file, "{}");

            new JsonProvider(file);
        }

        [Fact()]
        public void JsonProviderTestWithoutFile()
        {
            var path = Path.GetTempPath();
            var notExistFile = path + "/hello.txt";
            File.Delete(notExistFile);
            Assert.False(File.Exists(notExistFile));
            new JsonProvider(notExistFile);
            Assert.True(File.Exists(notExistFile));
            File.Delete(notExistFile);
        }


        public class Sample
        {
            public Sample(string first)
            {
                Key = first;
            }
            public string Key { get; set; }
        }
        [Fact()]
        public void RestoreTest()
        {
            var sampleJson = @"
{
    ""sample"":{""Key"":""outside""},
    ""list"": [
        {
            ""Key"":""in list""
        }
    ]
}";
            using var file = new TemporaryFile();
            File.WriteAllText(file, sampleJson);
            var jsonProvider = new JsonProvider(file);
            Assert.Equal("outside", jsonProvider.Restore("sample", new Sample("")).Key);
            Assert.Collection(jsonProvider.Restore("list",new List<Sample>()),
                (item) => Assert.Equal("in list", item.Key));
        }

        [Fact()]
        public void StoreTest()
        {
            using var file = new TemporaryFile();
            File.WriteAllText(file, "{}");

            var jsonProvider = new JsonProvider(file);
            var sample = new Sample("hello");

            jsonProvider.Store("sample", sample);

            Task.Delay(1000).Wait();
            var expect = @"{
  ""sample"": {
    ""Key"": ""hello""
  }
}";
            Assert.Equal(expect, File.ReadAllText(file));
        }
    }
}