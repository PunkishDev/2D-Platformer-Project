using UnityEngine;

public class GroundFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float dampening = 0.5f;
    [SerializeField]
    private float moveTowardsSpeed = 0.7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float diff = transform.position.x - player.position.x;

        if (diff > dampening || diff < -dampening)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), moveTowardsSpeed);
        }
        
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
