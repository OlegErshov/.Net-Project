using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializerLib
{
    public interface ISerializer
    {
        IEnumerable<T>? DeserializeJson<T>(string fileName);
        Task<IEnumerable<T>?> DeserializeJsonAsync<T>(string fileName);
        T? DeserializeXml<T>(string fileName);
        Task<IEnumerable<T>?> DeserializeXmlAsync<T>(string fileName);
        void SerializeJson<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null);
        Task SerializeJsonAsync<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null);
        void SerializeXml<T>(T collection, string fileName);
        Task SerializeXmlAsync<T>(IEnumerable<T> collection, string fileName);
    }
}
