using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NewMazeAndBall
{
    internal class JsonData<T> : IData<T>
    {
        public void Save(List<T> data, string path = null)
        {
            List<string> savedData = new List<string>();
            foreach (var item in data)
            {
                var str = JsonUtility.ToJson(item);
                savedData.Add(Crypto.CryptoXOR(str));
            }
            File.WriteAllLines(path, savedData);
        }

        public List<T> Load(string path = null)
        {
            List<T> load = new List<T>();
            var loadedData = File.ReadAllLines(path);
            for (int i = 0; i < loadedData.Length; i++)
            {
                load.Add(JsonUtility.FromJson<T>(Crypto.CryptoXOR(loadedData[i])));
            }

            return load;
        }
    }
}
