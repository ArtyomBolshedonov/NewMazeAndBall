using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace NewMazeAndBall
{
    public class SerializableXMLData<T> : IData<T>
    {
        private static XmlSerializer _formatter;

        public SerializableXMLData()
        {
            _formatter = new XmlSerializer(typeof(List<T>));
        }

        public void Save(List<T> data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path)) return;
            using (var fs = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fs, data);
            }
        }

        public List<T> Load(string path)
        {
            List<T> result;
            if (!File.Exists(path)) return default;
            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (List<T>)_formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
