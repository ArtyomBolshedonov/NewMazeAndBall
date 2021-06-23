using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class BonusReferences
    {
        private GameObject _goodBonus;
        private GameObject _badBonus;

        internal GameObject GoodBonus
        {
            get
            {
                _goodBonus = Resources.Load<GameObject>("GoodBonus");
                if (_goodBonus == null)
                {
                    throw new System.Exception("Нет модели хорошего бонуса в папке ресурсов.");
                }
                return _goodBonus;
            }
        }

        internal GameObject BadBonus
        {
            get
            {
                _badBonus = Resources.Load<GameObject>("BadBonus");
                if (_badBonus == null)
                {
                    throw new System.Exception("Нет модели плохого бонуса в папке ресурсов.");
                }
                return _badBonus;
            }
        }
    }
}
