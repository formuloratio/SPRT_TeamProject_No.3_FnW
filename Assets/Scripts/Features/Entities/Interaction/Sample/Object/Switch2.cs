using UnityEngine;

namespace Features.Entities.Interaction.Sample
{
    public class Switch2 : MonoBehaviour
    {
        [SerializeField] private GameObject reactiveObject;
        [SerializeField] private ActionType actionType = ActionType.Maintain;

        private IReactiveObject _reactiveObject;
        private bool _isPlayerOn = false;

        void Awake()
        {
            if (reactiveObject != null)
            {
                _reactiveObject = reactiveObject.GetComponent<IReactiveObject>();
            }
        }

        void Update()
        {
            if (_reactiveObject == null || reactiveObject == null) return;

            if (actionType == ActionType.Maintain)
            {
                if (_isPlayerOn)
                {
                    _reactiveObject?.Activate();
                }
                else
                {
                    _reactiveObject?.Deactivate();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_reactiveObject == null || reactiveObject == null) return;
            if (other.TryGetComponent<Player2>(out var player))
            {
                _isPlayerOn = true;
                if (actionType == ActionType.Once)
                {
                    _reactiveObject?.Activate();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_reactiveObject == null || reactiveObject == null) return;
            if (other.TryGetComponent<Player2>(out var player))
            {
                _isPlayerOn = false;
                if (actionType == ActionType.Once)
                {
                    _reactiveObject?.Deactivate();
                }
            }
        }
    }

}