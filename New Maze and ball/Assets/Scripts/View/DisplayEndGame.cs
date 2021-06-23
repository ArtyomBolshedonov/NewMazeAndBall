using System;
using UnityEngine;
using UnityEngine.UI;


namespace NewMazeAndBall
{
    internal sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        internal DisplayEndGame(GameObject gameOver)
        {
            _finishGameLabel = gameOver.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        internal void GameOver(object o, CaughtPlayerEventArgs args)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {o.ToString()} {args._color} цвета";
        }

        internal void WinGame()
        {
            _finishGameLabel.text = "Поздравляем! Вы выиграли!";
        }
    }
}
