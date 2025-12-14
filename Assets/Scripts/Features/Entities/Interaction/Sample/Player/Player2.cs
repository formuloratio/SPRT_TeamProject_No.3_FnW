using UnityEngine;
using Utils;

namespace Features.Entities.Interaction.Sample
{
    public class Player2 : MonoBehaviour, IElementObject
    {
        [SerializeField] private ElementType _elementType;

        public ElementType ElementType
        {
            get => _elementType;
            set => _elementType = value;
        }

        [SerializeField] private float _speed = 5;
        [SerializeField] private float _jumpForce = 5;

        private Rigidbody2D _rigidbody2D;
        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2D.velocity = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);
        }

        public void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}