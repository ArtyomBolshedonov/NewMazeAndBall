using System;
using System.Collections.Generic;
using UnityEngine;


namespace NewMazeAndBall
{
    /// <summary>
    /// Эта система сохранения проста в применении, но ее не рекомендуется использовать по ряду причин:
    /// В операционной системе Windows PlayerPrefs пишет данные в реестр;
    /// PlayerPrefs имеет лимит по объему записанной информации – 1 мб.
    /// </summary>
    internal class PlayerPrefsData : IData<SavedData>
    {
        public void Save(List<SavedData> data, string path = null)
        {
            foreach (var item in data)
            {
                PlayerPrefs.SetString("Name", item.Name);
                PlayerPrefs.SetFloat("PosX", item.Position.X);
                PlayerPrefs.SetFloat("PosY", item.Position.Y);
                PlayerPrefs.SetFloat("PosZ", item.Position.Z);
                PlayerPrefs.SetString("IsEnable", item.IsEnabled.ToString());
            }
            //-----------------------------
            PlayerPrefs.Save();
        }

        public List<SavedData> Load(string path = null)
        {
            List<SavedData> LoadedData = new List<SavedData>();

            var result = new SavedData();

            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }
            key = "PosX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }
            key = "PosY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Y = PlayerPrefs.GetFloat(key);
            }
            key = "PosZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Z = PlayerPrefs.GetFloat(key);
            }
            key = "IsEnable";
            if (PlayerPrefs.HasKey(key))
            {
                result.IsEnabled = Convert.ToBoolean(PlayerPrefs.GetString(key));
            }

            LoadedData.Add(result);

            return LoadedData;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
