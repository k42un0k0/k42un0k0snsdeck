using Xunit;
using System.Collections.Generic;
using K42un0k0SnsDeckTests;
using System.IO;
using System.Threading.Tasks;

namespace K42un0k0SnsDeck.Infra.Provider.Tests
{
    public class JsonProviderTests
    {
        [Fact()]
        public void JsonProviderTest()
        {
            using var file = new TemporaryFile();
            File.WriteAllText(file, "{}");

            var jsonProvider = new JsonProvider(file);
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
            Assert.Equal("outside", jsonProvider.Restore<Sample>("sample").Key);
            Assert.Collection(jsonProvider.Restore<List<Sample>>("list"),
                (item) => Assert.Equal("in list", item.Key));
        }

        [Fact()]
        public async void StoreTest()
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