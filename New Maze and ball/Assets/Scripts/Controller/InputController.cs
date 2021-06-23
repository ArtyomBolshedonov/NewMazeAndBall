using UnityEngine;


namespace NewMazeAndBall
{
    internal sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private ListExecuteObject _interactiveObject;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        public InputController(PlayerBase player, ListExecuteObject listExecuteObject)
        {
            _playerBase = player;
            _interactiveObject = listExecuteObject;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            Save();
            Load();
        }

        private void Save()
        {
            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase, _interactiveObject);
            }
        }

        private void Load()
        {
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase, _interactiveObject);
            }
        }
    }
}
