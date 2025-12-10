using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindFirstObjectByType<SoundManager>().PlaySound("Win");
            PlayerPrefs.SetInt("Coins", FindFirstObjectByType<PlayerMove>().coins);
            Time.timeScale = 0;
            winUI.SetActive(true);
        }
    }
}
