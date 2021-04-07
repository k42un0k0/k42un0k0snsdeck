using K42un0k0SnsDeck.Common;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json;

namespace K42un0k0SnsDeck.Infra.Provider
{
    public interface IJsonProvider
    {
        public T Restore<T>(string name, T fallback);
        public void Store(string name, object obj);

    }
    public class JsonProvider: IJsonProvider
    {
        private readonly string _path;
        private JObject _data;
        private JobScheduler _jobScheduler = new JobScheduler();
 
        public JsonProvider(string path)
        {
            _path = path;
            try
            {
                ReadFile();
            }catch (FileNotFoundException)
            {
                File.WriteAllText(_path, "{}");
                ReadFile();
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path));
                File.WriteAllText(_path, "{}");
                ReadFile();
            }
        }

        private void ReadFile()
        {
            string content = File.ReadAllText(_path);
            _data = JObject.Parse(content);
        }

        private void WriteFile()
        {
            var json = _data.ToString();
            File.WriteAllText(_path, json);
        }

        public T Restore<T>(string name, T fallback)
        {
            _jobScheduler.Enqueue(ReadFile);

            var data = _data[name];
            if (data == null) return fallback;
            return data.ToObject<T>();
        }
        public void Store(string name, object obj)
        {
            var json = JsonSerializer.Serialize(obj);
            _data[name] = JToken.Parse(json);
            _jobScheduler.Enqueue(WriteFile);
        }
    }
}
