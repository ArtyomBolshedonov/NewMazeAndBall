using UnityEngine;
using UnityEngine.UI;

namespace NewMazeAndBall
{
    internal sealed class UIReferences
    {
        private GameObject _bonus;
        private GameObject _gameOver;
        private Canvas _canvas;
        private Button _restartButton;

        internal Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        internal GameObject Bonus
        {
            get
            {
                if (_bonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonus");
                    _bonus = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _bonus;
            }
        }

        internal GameObject GameOver
        {
            get
            {
                if (_gameOver == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/GameOver");
                    _gameOver = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _gameOver;
            }
        }
        internal Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }
    }
}
