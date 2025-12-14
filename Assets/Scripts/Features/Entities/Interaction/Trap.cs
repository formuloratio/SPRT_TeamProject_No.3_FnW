using Features.Entities;
using UnityEngine;

// 스위치 상호작용으로 제거 가능한 함점
public class Trap : InteractionObject
{
    // 스위치 인덱스랑 같아야 함 10 ~ 19 사이 지정
    public int tripIndex = 10;

    void Start()
    {
        GetObjectIndex();
    }

    void Update()
    {
        RemoveTrip();
    }

    public void RemoveTrip()
    {
        if (SwitchingManager.Instance.isSwitching == true && SwitchingManager.Instance.switchTagCompare[tripIndex] == 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWater"))
        {
            if (obstacleIndex == fireIndex)
            {
                //게임 오버
                Destroy(collision.gameObject.gameObject);
                Debug.Log("죽었습니다.");
                GameOverManager.Instance.ShowGameOver();
            }
        }
        else if (collision.gameObject.CompareTag("PlayerFire"))
        {
            if (obstacleIndex == waterIndex)
            {
                //게임 오버
                Destroy(collision.gameObject.gameObject);
                Debug.Log("죽었습니다.");
                GameOverManager.Instance.ShowGameOver();
            }
        }
    }
}
