using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace NewMazeAndBall
{
    /// <summary>
    /// Application.dataPath; Содержит путь к папке игровых данных
    ///Application.persistentDataPath; Путь к постоянной директории данных
    ///Application.streamingAssetsPath; Путь к папке StreamingAssets
    ///Application.temporaryCachePath; Путь к временным данным/директории кэша
    /// </summary>
    internal sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "savedData.txt";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                //_data = new StreamData();
                //_data = new XMLData();
                //_data = new BinarySerializationData<SavedData>();
                //_data = new SerializableXMLData<SavedData>();
                //_data = new PlayerPrefsData();//В операционной системе Windows PlayerPrefs пишет данные в реестр;
                //PlayerPrefs имеет лимит по объему записанной информации – 1 мб.
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);

        }

        public void Save(PlayerBase player, ListExecuteObject listExecuteObject)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            List<SavedData> gameData = new List<SavedData>();
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = player.name,
                IsEnabled = player.isActiveAndEnabled,
            };
            gameData.Add(savePlayer);
            foreach (var o in listExecuteObject)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    var saveInteractiveObject = new SavedData
                    {
                        Position = interactiveObject.transform.position,
                        Name = interactiveObject.name,
                        IsEnabled = interactiveObject.isActiveAndEnabled,
                    };
                    gameData.Add(saveInteractiveObject);
                }
            }
            _data.Save(gameData, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player, ListExecuteObject listExecuteObject)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            foreach (var item in _data.Load(file))
            {
                if (item.Name == "Player(Clone)")
                {
                    player.transform.position = item.Position;
                    player.name = item.Name;
                    player.gameObject.SetActive(item.IsEnabled);
                }
                foreach (var o in listExecuteObject)
                {
                    if (o is InteractiveObject interactiveObject && item.Name == interactiveObject.name && !interactiveObject.IsLoaded)
                    {
                        interactiveObject.transform.position = item.Position;
                        interactiveObject.name = item.Name;
                        interactiveObject.gameObject.SetActive(item.IsEnabled);
                        interactiveObject.IsLoaded = true;
                        break;
                    }
                }
                Debug.Log(item);
            }
        }
    }
}
