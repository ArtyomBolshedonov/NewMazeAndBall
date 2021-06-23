using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;


namespace NewMazeAndBall
{
    internal sealed class BonusCreator
    {
        private BonusReferences _bonusReferences;
        private MazeCreator _maze;
        private PlayerBase _player;
        private List<MazeGenerator.genCell> _corridors;
        private int _goodBonusCount;
        private int _badBonusCount;

        internal BonusCreator(int goodBonusCount, int badBonusCount, MazeCreator maze, PlayerBase player)
        {
            _bonusReferences = new BonusReferences();
            _goodBonusCount = goodBonusCount;
            _badBonusCount = badBonusCount;
            _maze = maze;
            _player = player;
            _corridors = _maze.GetCorridors();
        }

        internal void GenerateBonus()
        {
            var playerCell = new MazeGenerator.genCell();
            playerCell.Row = Convert.ToInt32(_player.transform.position.z);
            playerCell.Col = Convert.ToInt32(_player.transform.position.x);
            _corridors.Remove(playerCell);
            CheckCorridors();
            CreateBonus(_goodBonusCount, _bonusReferences.GoodBonus);
            CreateBonus(_badBonusCount, _bonusReferences.BadBonus);
        }

        private void CreateBonus(int bonusCount, GameObject Bonus)
        {
            var localBonusCount = 0;
            for (int i = 0; i < bonusCount; i++)
            {
                var rand = UnityEngine.Random.Range(0, _corridors.Count);
                var bonusPosition = new Vector3(_corridors[rand].Col, Bonus.transform.localScale.y / 2, _corridors[rand].Row);
                UnityEngine.Object.Instantiate(Bonus, bonusPosition, Quaternion.identity);
                _corridors.Remove(_corridors[rand]);
                localBonusCount++;
            }
            Log($"{Bonus.name} сгенерировано: {localBonusCount}");
        }

        private void CheckCorridors()
        {
            if (_corridors.Count < _goodBonusCount + _badBonusCount)
            {
                throw new Exception("Слишком много бонусов запрошено для создания. Уменьшите общее количество бонусов!");
            }
        }
    }
}
