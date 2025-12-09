using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager sm = FindFirstObjectByType<SoundManager>();
            sm.PlaySound("Coin");
            PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
            player.coins++;
            coinText.text = player.coins.ToString();
            Destroy(gameObject);
        }
    }
}
