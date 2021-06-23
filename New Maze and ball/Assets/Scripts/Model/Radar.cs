using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace NewMazeAndBall
{
    internal sealed class Radar : MonoBehaviour
    {
        internal Transform _playerPos;
        internal static List<RadarObject> RadObjects = new List<RadarObject>();

        private void Awake()
        {
            _playerPos = Camera.main.transform;
        }
        internal static void RegisterRadarObject(GameObject o, Image i)
        {
            Image image = Instantiate(i);
            RadObjects.Add(new RadarObject { Owner = o, Icon = image });
        }
        internal static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadObjects)
            {
                if (t.Owner == o)
                {
                    Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }
    }
}
