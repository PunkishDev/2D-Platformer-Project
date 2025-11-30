using UnityEngine;

public class TakingDamage : MonoBehaviour
{

    public int damageAmount = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //Access the PlayerHealth script and apply damage
            collision.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
