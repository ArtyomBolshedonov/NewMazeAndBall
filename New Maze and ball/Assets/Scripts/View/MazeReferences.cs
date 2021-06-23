using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class MazeReferences
    {
        private GameObject _wall;
        private GameObject _floor;

        internal GameObject Wall
        {
            get
            {
                _wall = Resources.Load<GameObject>("Wall");
                if (_wall == null)
                {
                    throw new System.Exception("Нет модели стены в папке ресурсов для генерации лабиринта.");
                }
                return _wall;
            }
        }

        internal GameObject Floor
        {
            get
            {
                _floor = Resources.Load<GameObject>("Floor");
                if (_floor == null)
                {
                    throw new System.Exception("Нет модели пола в папке ресурсов для генерации лабиринта.");
                }
                return _floor;
            }
        }
    }
}
