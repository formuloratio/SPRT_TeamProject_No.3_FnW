using Features.Entities;
using UnityEngine;

public class Wall : InteractionObject
{
    void Start()
    {
        GetObjectIndex();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //플레이어가 물일 때
        if (collision.gameObject.CompareTag("PlayerWater"))
        {
            if (obstacleIndex == fireIndex)
            {
                //불 벽 삭제
                Destroy(this.gameObject);
            }
        }
        //플레이어가 불일 때
        else if (collision.gameObject.CompareTag("PlayerFire"))
        {
            if (obstacleIndex == waterIndex)
            {
                //물 벽 삭제
                Destroy(this.gameObject);
            }
        }

    }
}
