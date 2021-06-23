using System;
using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
    {
        [SerializeField] private float _bonusTime = 10.0f;
        private PlayerBall _player;
        private float _lengthFlay;
        private float _speedRotation;
        private bool _isAccelerate = false;

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        internal event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        public delegate void SlyghtlyCaughtPlayerChange();
        public event SlyghtlyCaughtPlayerChange SlyghtlyCaughtPlayer;

        private void Awake()
        {
            _lengthFlay = UnityEngine.Random.Range(1.0f, 5.0f);
            _speedRotation = UnityEngine.Random.Range(10.0f, 50.0f);
            _player = FindObjectOfType<PlayerBall>();
        }

        protected override void Interaction()
        {
            _player.ChangeSpeed(_bonusTime, _isAccelerate);
            _player.Lives--;
            if (_player.Lives > 0)
            {
                SlyghtlyCaughtPlayer?.Invoke();
                _player.Kick();
            }
            else _caughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_color));
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Rotate();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }
    }
}
