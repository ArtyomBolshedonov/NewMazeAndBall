using System;
using UnityEngine;


namespace NewMazeAndBall
{
    internal class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        [SerializeField] private float _bonusTime = 10.0f;
        [SerializeField] internal int _point = 1;
        public event Action<int> OnPointChange = delegate (int i) { };
        private Material _material;
        private PlayerBall _player;
        private float _lengthFlay;
        private bool _isAccelerate = true;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = UnityEngine.Random.Range(1.0f, 5.0f);
            _player = FindObjectOfType<PlayerBall>();
        }

        protected override void Interaction()
        {
            _player.Scores++;
            OnPointChange.Invoke(_point);
            _player.ChangeSpeed(_bonusTime, _isAccelerate);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Flick();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
