using System;
using UnityEngine;
using UnityEngine.UI;


namespace NewMazeAndBall
{
    internal sealed class DisplayBonuses
    {
        private Text _bonusLable;
        internal Text Text
        {
            get => _bonusLable;
            private set { }
        }
        internal DisplayBonuses(GameObject bonus)
        {
            _bonusLable = bonus.GetComponentInChildren<Text>();
            _bonusLable.text = String.Empty;
        }

        internal void Display(int value)
        {
            _bonusLable.text = $"Вы набрали {value}";
        }
    }
}
