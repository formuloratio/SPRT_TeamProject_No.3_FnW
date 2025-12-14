using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        Vector3 thisPos = transform.position;
        thisPos.x -= speed * Time.deltaTime;
        transform.position = thisPos;
        if (transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWater") || (collision.gameObject.CompareTag("PlayerFire")))
        {
            Debug.Log("화살에 맞음");

            if (GameOverManager.Instance != null)
            {
                GameOverManager.Instance.ShowGameOver();
            }
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
