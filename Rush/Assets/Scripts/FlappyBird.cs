using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity = 1;
    public float cooldownTime = 0.5f; // Set the desired cooldown time here
    private float lastFlapTime = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastFlapTime >= cooldownTime)
        {
            rb.velocity = Vector2.up * velocity;
            lastFlapTime = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
