using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class RadarController : IExecute
    {
        private Transform _playerPos;
        private readonly float _mapScale = 2;
        private Radar _radar;
        internal RadarController(Radar radar)
        {
            _radar = radar;
            _playerPos = _radar._playerPos;
        }

        private void DrawRadarDots()
        {
            foreach (RadarObject radObject in Radar.RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position -
                _playerPos.position);
                float distToObject = Vector3.Distance(_playerPos.position,
                radObject.Owner.transform.position) * _mapScale;
                float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg -
                270 - _playerPos.eulerAngles.y;
                radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
                radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
                radObject.Icon.transform.SetParent(_radar.transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x,
                radarPos.z, 0) +
                _radar.transform.position;
            }
        }

        public void Execute()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }
}
