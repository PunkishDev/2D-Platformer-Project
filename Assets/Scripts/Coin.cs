using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
            player.coins = +1;
            Destroy(gameObject);
        }
    }
}
