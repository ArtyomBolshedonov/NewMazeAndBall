using UnityEngine;


namespace NewMazeAndBall
{
    internal abstract class PlayerBase : MonoBehaviour
    {
        [SerializeField] internal float _speed = 50.0f;
        [SerializeField] internal int _lifes = 3;

        internal abstract void Move(float x, float y, float z);

        internal int Lives
        {
            get
            {
                return _lifes;
            }
            set
            {
                _lifes = value;
            }
        }

        internal int Scores { get; set; }
    }
}
