using UnityEngine;


namespace NewMazeAndBall
{

    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private int _mapLengthX = 5;
        [SerializeField] private int _mapLengthY = 5;
        [SerializeField] private int _goodBonusCount = 1;
        [SerializeField] private int _badBonusCount = 1;
        [SerializeField] private PlayerType _playerType = PlayerType.Ball;
        private PlayerBase _player;
        private ListExecuteObject _interactiveObject;
        private PlayerCameraReferences _playerCameraReferences;
        private GameConstructor _game;
        private CameraController _cameraController;
        private InputController _inputController;
        private UIController _uIController;
        private EventController _eventController;
        private Radar _radar;
        private RadarController _radarController;
        private PhotoController _photoController;
        
        private void Start()
        {
            _playerCameraReferences = new PlayerCameraReferences();
            if(_playerType == PlayerType.Ball)
            {
                _player = _playerCameraReferences.PlayerBall;
            }
            _game = new GameConstructor(_mapLengthX, _mapLengthY, _goodBonusCount, _badBonusCount, _player);
            _game.GenerateGame();
            _interactiveObject = new ListExecuteObject();
            _cameraController = new CameraController(_player.transform, _playerCameraReferences.MainCamera.transform);
            _inputController = new InputController(_player, _interactiveObject);
            _uIController = new UIController();
            _radar = FindObjectOfType<Radar>();
            _radarController = new RadarController(_radar);
            _photoController = new PhotoController();
            _interactiveObject.AddExecuteObject(_cameraController);
            _interactiveObject.AddExecuteObject(_inputController);
            _interactiveObject.AddExecuteObject(_uIController);
            _interactiveObject.AddExecuteObject(_radarController);
            _interactiveObject.AddExecuteObject(_photoController);
            _eventController = new EventController(_interactiveObject, _uIController, _cameraController);
            _eventController.AddEvent();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }
    }
}
