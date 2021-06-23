using System;
using System.Collections.Generic;
using System.IO;


namespace NewMazeAndBall
{
    internal sealed class StreamData : IData<SavedData>
    {
        public void Save(List<SavedData> data, string path = null)
        {
            if (path == null) return;
            using (var sw = new StreamWriter(path))
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item.Name);
                    sw.WriteLine(item.Position.X);
                    sw.WriteLine(item.Position.Y);
                    sw.WriteLine(item.Position.Z);
                    sw.WriteLine(item.IsEnabled);
                }
            }
        }
        public List<SavedData> Load(string path = null)
        {
            List<SavedData> LoadedData = new List<SavedData>();
            
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var result = new SavedData();
                    result.Name = sr.ReadLine();
                    result.Position.X = (float)Convert.ToDouble(sr.ReadLine());
                    result.Position.Y = (float)Convert.ToDouble(sr.ReadLine());
                    result.Position.Z = (float)Convert.ToDouble(sr.ReadLine());
                    result.IsEnabled = Convert.ToBoolean(sr.ReadLine());
                    LoadedData.Add(result);
                }
            }
            return LoadedData;
        }
    }
}
