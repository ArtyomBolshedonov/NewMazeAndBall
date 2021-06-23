using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace NewMazeAndBall
{
    internal class BinarySerializationData<T> : IData<T>
    {
        private static BinaryFormatter _formatter;

        internal BinarySerializationData()
        {
            _formatter = new BinaryFormatter();
        }

        public void Save(List<T> data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path)) return;
            if (!typeof(T).IsSerializable) return;
            using (var fs = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(fs, data);
            }
        }

        public List<T> Load(string path)
        {
            List<T> loadedData = null;
            if (!File.Exists(path)) return default(List<T>);
            using (var fs = new FileStream(path, FileMode.Open))
            {
                loadedData = (List<T>)_formatter.Deserialize(fs);
            }
            return loadedData;
        }
    }
}
