using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Starting health value for the Player
    public int health = 100;
    public SoundManager sm;

    //UI Management stuff
    public Slider healthBar;
    public GameObject DeadUI;

    // Reference to the Player's SpriteRenderer (used for flashing red)
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Get the SpriteRenderer component attached to the Player
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar.value = health;
        sm = FindFirstObjectByType<SoundManager>();
    }

    // Method to reduce health when damage is taken
    public void TakeDamage(int damageAmount)
    {
        sm.PlaySound("Hurt");
        health -= damageAmount; // subtract damage amount
        healthBar.value = health;
        StartCoroutine(BlinkRed()); // briefly flash red

        // If health reaches zero or below, call Die()
        if (health <= 0)
        {
            Die();
        }
    }

    // Coroutine to flash the Player red for 0.1 seconds
    private System.Collections.IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    // Reload the scene when the Player dies
    private void Die()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        FindFirstObjectByType<SoundManager>().PlaySound("Hurt");
        Time.timeScale = 0;
        DeadUI.SetActive(true);
    }
}
