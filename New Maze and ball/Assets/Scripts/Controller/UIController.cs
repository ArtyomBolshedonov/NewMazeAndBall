using UnityEngine;
using UnityEngine.UI;


namespace NewMazeAndBall
{
    internal sealed class UIController : IExecute, IFlicker
    {
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private Button _restartButton;
        private UIReferences _uIReferences;

        internal DisplayEndGame DislpayEndGame
        {
            get
            {
                return _displayEndGame;
            }
            private set { }
        }

        internal DisplayBonuses DisplayBonuses
        {
            get
            {
                return _displayBonuses;
            }
            private set { }
        }

        internal Button RestartButton
        {
            get
            {
                return _restartButton;
            }
            private set { }
        }

        internal UIController()
        {
            _uIReferences = new UIReferences();
            _displayEndGame = new DisplayEndGame(_uIReferences.GameOver);
            _displayBonuses = new DisplayBonuses(_uIReferences.Bonus);
            _restartButton = _uIReferences.RestartButton;

        }

        public void Execute()
        {
            Flick();
        }

        public void Flick()
        {
            _displayBonuses.Text.color = new Color(Mathf.PingPong(Time.time, 1.0f),
                Mathf.PingPong(Time.time, 1.0f), Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
