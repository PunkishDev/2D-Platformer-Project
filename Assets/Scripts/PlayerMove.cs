using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 input = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        //Getting horizontal input for movement
        input = new Vector2(Input.GetAxisRaw("Horizontal"), input.y); //Setting y to input.y since itll modify on another line for jump input
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
}
