using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //게임 오버
        Destroy(collision.gameObject);
        Debug.Log("죽었습니다.");
        GameOverManager.Instance.ShowGameOver();
    }
}
