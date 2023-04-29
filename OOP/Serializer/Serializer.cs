using System.Text.Json;

namespace Serializer
{
    public class Serializer : ISerializer
    {
        public IEnumerable<T>? DeserializeJson<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>?> DeserializeJsonAsync<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? DeserializeXml<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>?> DeserializeXmlAsync<T>(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SerializeJson<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public Task SerializeJsonAsync<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public void SerializeXml<T>(IEnumerable<T> collection, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task SerializeXmlAsync<T>(IEnumerable<T> collection, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}