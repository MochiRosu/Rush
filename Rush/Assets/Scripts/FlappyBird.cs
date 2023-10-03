using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public float velocity = 1;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.up * velocity;
    }
}
