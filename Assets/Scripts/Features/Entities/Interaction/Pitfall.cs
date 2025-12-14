using Features.Entities;
using UnityEngine;

public class Pitfall : InteractionObject
{
    void Start()
    {
        GetObjectIndex();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerWater"))
        {
            if (obstacleIndex == fireIndex)
            {
                //게임 오버
                Destroy(collider.gameObject);
                Debug.Log("죽었습니다.");
                GameOverManager.Instance.ShowGameOver();
            }
        }
        else if (collider.CompareTag("PlayerFire"))
        {
            if (obstacleIndex == waterIndex)
            {
                //게임 오버
                Destroy(collider.gameObject);
                Debug.Log("죽었습니다.");
                GameOverManager.Instance.ShowGameOver();
            }
        }
    }
}
