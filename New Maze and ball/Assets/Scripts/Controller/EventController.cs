using System;
using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class EventController : IDisposable
    {
        private ListExecuteObject _interactiveObject;
        private UIController _uIController;
        private CameraController _cameraController;
        private SceneController _sceneController;
        private int _countBonuses;
        private int _goodBonusCount;

        internal EventController(ListExecuteObject interactiveObject, UIController uIController, CameraController cameraController)
        {
            _interactiveObject = interactiveObject;
            _uIController = uIController;
            _cameraController = cameraController;
            _sceneController = new SceneController();
        }

        internal void AddEvent()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _uIController.DislpayEndGame.GameOver;
                    badBonus.SlyghtlyCaughtPlayer += _cameraController.CameraShacking;
                }
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                    _goodBonusCount++;
                }
            }
            _uIController.RestartButton.onClick.AddListener(_sceneController.RestartGame);
            _uIController.RestartButton.gameObject.SetActive(false);
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            _uIController.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _uIController.DisplayBonuses.Display(_countBonuses);
            if (_countBonuses == _goodBonusCount)
            {
                WinGame();
            }
        }

        private void WinGame()
        {
            _uIController.DislpayEndGame.WinGame();
            _uIController.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= CaughtPlayer;
                    badBonus.CaughtPlayer -= _uIController.DislpayEndGame.GameOver;
                    badBonus.SlyghtlyCaughtPlayer -= _cameraController.CameraShacking;
                }
                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }
    }
}
