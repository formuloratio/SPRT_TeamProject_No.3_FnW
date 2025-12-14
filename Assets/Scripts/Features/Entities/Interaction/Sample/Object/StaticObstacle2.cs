using UnityEngine;

namespace Features.Entities.Interaction.Sample
{
    public class StaticObstacle2 : Obstacle2
    {
        private Collider2D _collider;
        private bool _isTriggerred;

        void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_isTriggerred) return;
            if(collision.gameObject.TryGetComponent<Player2>(out var player))
            {
                bool isElementEqual = player.ElementType == this.elementType;
                if (this.obstacleType == ObstacleType.Vanishing)
                {
                    if(isElementEqual) Destroy(this.gameObject);
                }
                else if (this.obstacleType == ObstacleType.Passing)
                {
                    if (!isElementEqual)
                    {
                        _collider.isTrigger = true;
                        _isTriggerred = true;
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (this.obstacleType != ObstacleType.Passing) return;

            if (other.TryGetComponent<Player2>(out var player))
            {
                _collider.isTrigger = false;
                _isTriggerred = false;
            }
        }

    }

}