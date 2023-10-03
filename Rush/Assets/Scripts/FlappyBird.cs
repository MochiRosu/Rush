using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public float velocity = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up * velocity;   
        }
    }
    
}
