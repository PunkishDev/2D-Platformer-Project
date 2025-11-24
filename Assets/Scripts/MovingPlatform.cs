using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float distance = 3f; //how far it moves from start point
    public float speed = 2f; //how fast the platform moves
    private Vector3 startPos; //where it starts
    private int direction = 1; //which way it goes. 1 = right, -1 = left
                               //
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; // save the starting position when game begins
    }

    // Update is called once per frame
    void Update()
    {
        //move platform left/right each frame
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);


        //if platform has moved the set distance from start
        if (Mathf.Abs(transform.position.x - startPos.x) >= distance) 
        {
            //reverse direction
            direction *= -1;
        }

    }
    ///////
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player lands on the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            //make the player a child of the platform object
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //if the player leaves the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
