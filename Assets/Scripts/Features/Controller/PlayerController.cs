using System.Collections;
using Core;
using Features.Entities;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Player _player;

    [SerializeField] private BaseController player1;
    [SerializeField] private BaseController player2;

    private BaseController currentPlayer;
    private AudioManager _audioManager;

    private void Awake()
    {
        // 자동 탐색
        if (player1 == null || player2 == null)
        {
            BaseController[] players = FindObjectsOfType<BaseController>();

            if (players.Length >= 2)
            {
                player1 = players[0];
                player2 = players[1];
            }
        }
        _audioManager = AudioManager.Instance;
    }

    private void Start()
    {
        if (player1 == null || player2 == null)
        {
            return;
        }

        // 초기 활성화 설정
        currentPlayer = player1;

        player1.SetActive(true);
        player2.SetActive(false);

        player1.Selected(true);
        player2.Selected(false);
    }

    private void Update()
    {
        if (currentPlayer == null) return;

        //1번입력시 드워프
        //2번입력시 엘프
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchPlayer(player1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchPlayer(player2);

    }

    //주 플레이어를 한 캐릭터만 선택하도록
    void SwitchPlayer(BaseController newPlayer)
    {
        if (newPlayer == null || currentPlayer == null) return;
        if (currentPlayer == newPlayer) return;

        // 점프 중 전환 금지
        if (!currentPlayer.IsGrounded())
            return;

        currentPlayer.SetActive(false);
        currentPlayer.Selected(false);

        newPlayer.SetActive(true);
        newPlayer.Selected(true);

        currentPlayer = newPlayer;
        _audioManager.PlaySfx(_audioManager.playerChange);
    }

    IEnumerator LateSwitch(BaseController newPlayer)
    {
        currentPlayer.SetActive(false);
        currentPlayer.Selected(false);

        yield return null; // 한 프레임 대기

        newPlayer.SetActive(true);
        newPlayer.Selected(true);

        currentPlayer = newPlayer;
    }
}


