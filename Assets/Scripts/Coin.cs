using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager sm = FindFirstObjectByType<SoundManager>();
            sm.PlaySound("Coin");
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
            player.coins = +1;
            Destroy(gameObject);
        }
    }
}
