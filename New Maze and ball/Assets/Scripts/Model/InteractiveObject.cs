using System;
using UnityEngine;


namespace NewMazeAndBall
{
    internal abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>, IExecute
    {
        protected Color _color;
        private bool _isInteractable;
        internal bool IsLoaded { get; set; }

        public bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                gameObject.SetActive(_isInteractable);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }

        protected abstract void Interaction();
        public abstract void Execute();

        private void Start()
        {
            Action();
            IsInteractable = true;
        }
        public void Action()
        {
            _color = UnityEngine.Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}
