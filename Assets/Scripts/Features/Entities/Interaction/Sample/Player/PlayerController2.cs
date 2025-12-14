using UnityEngine;

namespace Features.Entities.Interaction.Sample
{
    public class PlayerController2 : MonoBehaviour
    {
        Player2 _player;

        [SerializeField] private Player2 playerFire;
        [SerializeField] private Player2 playerWater;

        void Awake()
        {
            _player = playerFire;
        }

        void FixedUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");

            Vector2 movement = new Vector2(horizontal, 0).normalized;
            _player.Move(movement);

            if (Input.GetKeyDown(KeyCode.W))
            {
                _player.Jump();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchingPlayer(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchingPlayer(2);
            }
        }
        void SwitchingPlayer(int num)
        {
            if (num == 1)
            {
                _player = playerFire;
            }else if (num == 2)
            {
                _player = playerWater;
            }
        }
    }
}