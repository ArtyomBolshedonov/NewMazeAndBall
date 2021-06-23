using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class XMLData : IData<SavedData>
    {
        public void Save(List<SavedData> data, string path = "")
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("ListSavedData");
            xmlDoc.AppendChild(rootNode);

            foreach (var item in data)
            {
                var saveElement = xmlDoc.CreateElement("SaveData");
                rootNode.AppendChild(saveElement);

                var element = xmlDoc.CreateElement("Name");
                element.SetAttribute("value", item.Name);
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PosX");
                element.SetAttribute("value", item.Position.X.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PosY");
                element.SetAttribute("value", item.Position.Y.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("PosZ");
                element.SetAttribute("value", item.Position.Z.ToString());
                rootNode.AppendChild(element);

                element = xmlDoc.CreateElement("IsEnable");
                element.SetAttribute("value", item.IsEnabled.ToString());
                rootNode.AppendChild(element);
            }

            XmlNode userNode = xmlDoc.CreateElement("Info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " +
                                 Application.systemLanguage;
            rootNode.AppendChild(userNode);

            xmlDoc.Save(path);
        }

        public List<SavedData> Load(string path = "")
        {
            List<SavedData> loadedData = new List<SavedData>();
            if (!File.Exists(path)) return loadedData;
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var result = new SavedData();
                    var key = "Name";
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                    }
                    key = "PosX";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.X = float.Parse(reader.GetAttribute("value"));
                    }
                    key = "PosY";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Y = float.Parse(reader.GetAttribute("value"));
                    }
                    key = "PosZ";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Z = float.Parse(reader.GetAttribute("value"));
                    }
                    key = "IsEnable";
                    if (reader.IsStartElement(key))
                    {
                        result.IsEnabled = bool.Parse(reader.GetAttribute("value"));
                    }
                    loadedData.Add(result);
                }
            }
            return loadedData;
        }
    }
}
