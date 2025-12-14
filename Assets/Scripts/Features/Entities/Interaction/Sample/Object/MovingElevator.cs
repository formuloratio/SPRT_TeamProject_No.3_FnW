using UnityEngine;

namespace Features.Entities.Interaction.Sample
{
    public class MovingElevator : MonoBehaviour, IReactiveObject
    {
        private ActionType _actionType = ActionType.Maintain;
        public ActionType ActionType => _actionType;

        private ReactiveType _reactiveType = ReactiveType.Moving;
        public ReactiveType ReactiveType => _reactiveType;

        [SerializeField]private Vector2 targetPosition;
        [SerializeField]private float movingSpeed;

        Rigidbody2D _rigidbody2D;
        private Vector2 _originalPosition;

        void Awake()
        {
            this._rigidbody2D = this.GetComponent<Rigidbody2D>();
            _originalPosition = this.transform.position;
        }

        public void Activate()
        {
            Vector2 currentPos = _rigidbody2D.position;
            Vector2 newPos = Vector2.MoveTowards(currentPos, targetPosition, movingSpeed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(newPos);
        }

        public void Deactivate()
        {
            Vector2 currentPos = _rigidbody2D.position;
            Vector2 newPos = Vector2.MoveTowards(currentPos, _originalPosition, movingSpeed * Time.fixedDeltaTime);
            _rigidbody2D.MovePosition(newPos);
        }
    }
}