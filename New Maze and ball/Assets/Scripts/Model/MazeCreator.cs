using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Debug;


namespace NewMazeAndBall
{
    internal sealed class MazeCreator
    {
        private GameObject _maze;
        private MazeGenerator _map;
        private MazeReferences _mazeReferences;
        private float _floorOffsetX;
        private float _floorOffsetY;
        private float _floorScalePerUnityMetres = 10.0f;

        internal MazeCreator(int mapLengthX, int mapLengthY)
        {
            _mazeReferences = new MazeReferences();
            if (mapLengthX < 5 || mapLengthY < 5 || mapLengthX % 2 == 0 || mapLengthY % 2 == 0)
            {
                throw new System.Exception("Размеры лабиринта должны быть больше 5 и строго нечётными!");
            }
            _maze = new GameObject("Maze");
            _floorOffsetX = mapLengthX / 2;
            _floorOffsetY = mapLengthY / 2;
            _mazeReferences.Floor.transform.localScale = new Vector3(mapLengthX / _floorScalePerUnityMetres,
                        _mazeReferences.Floor.transform.localScale.y, mapLengthY / _floorScalePerUnityMetres);
            _map = new MazeGenerator(mapLengthX, mapLengthY);
            _map.ClearMap(ref _map.map);
            _map.RemoveWall(ref _map.map);
        }

        internal void GenerateMap()
        {
            int wallCount = 0;

            Object.Instantiate(_mazeReferences.Floor, new Vector3(_floorOffsetX, 0, _floorOffsetY), Quaternion.identity).
                            transform.SetParent(_maze.transform);

            for (int i = 0; i < _map.map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.map.GetLength(1); j++)
                {
                    if (_map.map[i, j].Value == -1)
                    {
                        Object.Instantiate(_mazeReferences.Wall, new Vector3(i, _mazeReferences.Wall.transform.localScale.y/2, j),
                            Quaternion.identity).transform.SetParent(_maze.transform);
                        wallCount++;
                    }
                }
            }

            Log($"Стен сгенерировано: {wallCount}");
        }

        internal List<MazeGenerator.genCell> GetCorridors()
        {
            return _map.corridors;
        }

        internal int GetLength(int dimention)
        {
            return _map.map.GetLength(dimention);
        }
    }
}
