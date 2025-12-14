using Features.Entities;
using System.Collections;
using UnityEngine;

public class Switch : InteractionObject
{
    // 엘베랑 연결되는 스위치 id값 0~9
    //함정 제거와 연결되는 스위치 id값 10~19
    public int switchIndex = 0;

    Animator animator;

    private AudioManager _audioManager;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        _audioManager = AudioManager.Instance;
    }

    IEnumerator Start()
    {
        //인스턴스가 null이 아닐 때 넘어가도록
        yield return new WaitUntil(() => SwitchingManager.Instance != null);

        SwitchingManager.Instance.switchTagCompare[switchIndex] = 0;
        SwitchingManager.Instance.isSwitching = false;

        GetObjectIndex();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //플레이어가 물일 때
        if (collider.CompareTag("PlayerWater"))
        {
            if (obstacleIndex == waterIndex) //같은 물이면
            {
                //스위치 동작
                isWater = true;
                animator.SetBool("isSwitched", true);

                SwitchingManager.Instance.isSwitching = true;
                SwitchingManager.Instance.switchTagCompare[switchIndex] = 1;
                Debug.Log("스위치 ON");
                _audioManager.PlaySfx(_audioManager.switchClickSfx);
            }
        }
        //플레이어가 불일 때
        else if (collider.CompareTag("PlayerFire"))
        {
            if (obstacleIndex == fireIndex) //같은 불이면
            {
                //스위치 동작
                isFire = true;
                animator.SetBool("isSwitched", true);

                SwitchingManager.Instance.isSwitching = true;
                SwitchingManager.Instance.switchTagCompare[switchIndex] = 1;
                Debug.Log("스위치 ON");
                _audioManager.PlaySfx(_audioManager.switchClickSfx);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //플레이어가 물일 때
        if (collider.CompareTag("PlayerWater"))
        {
            if (obstacleIndex == waterIndex) //같은 물이면
            {
                //스위치 꺼짐
                SwitchingManager.Instance.isSwitching = false;
                isWater = false;
                animator.SetBool("isSwitched", false);

                SwitchingManager.Instance.switchTagCompare[switchIndex] = 0;
                Debug.Log("스위치 OFF");
            }
        }
        //플레이어가 불일 때
        else if (collider.CompareTag("PlayerFire"))
        {
            if (obstacleIndex == fireIndex) //같은 불이면
            {
                //스위치 꺼짐
                SwitchingManager.Instance.isSwitching = false;
                isFire = false;
                animator.SetBool("isSwitched", false);

                SwitchingManager.Instance.switchTagCompare[switchIndex] = 0;
                Debug.Log("스위치 OFF");
            }
        }
    }
}
