using System;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace SerializerLib
{
    public class Serializer : ISerializer
    {
        public IEnumerable<T>? DeserializeJson<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return JsonSerializer.Deserialize<IEnumerable<T>>(fs);
            }

        }

        public async Task<IEnumerable<T>?> DeserializeJsonAsync<T>(string fileName)
        {
            if(!File.Exists(fileName)) {
                throw new FileNotFoundException();
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(fs);
            }
        }

        public T? DeserializeXml<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
         
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(T));

                return (T)deserializer.Deserialize(fs);
            }

        }

        public Task<IEnumerable<T>?> DeserializeXmlAsync<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open,FileAccess.Read))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(IEnumerable<T>));

                return Task.Run(() => (IEnumerable<T>)deserializer.Deserialize(fs));
            }
        }

        public void SerializeJson<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null)
        {
           using(FileStream fs = new FileStream(fileName,FileMode.OpenOrCreate))
           {
                JsonSerializer.Serialize(fs, collection, options);
           }
        }

        public async Task SerializeJsonAsync<T>(IEnumerable<T> collection, string fileName, JsonSerializerOptions? options = null)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                foreach (T item in collection)
                {
                    await JsonSerializer.SerializeAsync<T>(fs, item);
                }
           
            }
        }

        public void SerializeXml<T>(T collection, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(fs, collection);
            }
        }

        public async Task SerializeXmlAsync<T>(IEnumerable<T> collection, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer= new XmlSerializer(typeof(T));
                await Task.Run(() => serializer.Serialize(fs, collection));
            }
        }
    }
}