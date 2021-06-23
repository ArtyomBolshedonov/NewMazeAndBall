using UnityEngine;


namespace NewMazeAndBall
{
    internal class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;
        private Animation _shacking;

        internal CameraController(Transform player, Transform mainCamera)
        {
            if (player == null)
            {
                throw new System.Exception("Нет игрока как цели у камеры.");
            }
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _player.position;
            _shacking = _mainCamera.gameObject.GetComponent<Animation>();
        }

        public void Execute()
        {
            _mainCamera.position = _player.position + _offset;
        }

        internal void CameraShacking()
        {
            _shacking.Play();
        }
    }
}
