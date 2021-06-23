using UnityEngine;
using System.Collections;


namespace NewMazeAndBall
{
    internal sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbody;
        private float _normalSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _normalSpeed = _speed;
        }

        internal override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * _speed);
        }

        internal void ChangeSpeed(float bonusTime, bool isAccelerated)
        {
            if (isAccelerated)
            {
                _speed *= 2;
            }
            else _speed /= 2;
            StartCoroutine(BonusTime(bonusTime));
        }

        internal void Kick()
        {
            _rigidbody.AddForce(-_rigidbody.velocity * _speed / 10, ForceMode.Impulse);
        }

        IEnumerator BonusTime(float bonusTime)
        {
            yield return new WaitForSeconds(bonusTime);
            _speed = _normalSpeed;
        }
    }
}
