using UnityEngine;

namespace Features.Scene
{
    public class GameScene : MonoBehaviour
    {
        private AudioManager _audioManager;

        void Awake()
        {
            _audioManager = AudioManager.Instance;
        }

        void Start()
        {
            _audioManager.PlayBgm(_audioManager.gameplayBgm);
        }
    }
}