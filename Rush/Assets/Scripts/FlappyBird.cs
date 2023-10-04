using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity = 1;
    public float cooldownTime = 0.5f;
    private float lastFlapTime = 0f;
    private Rigidbody2D rb;
    public AudioSource flapSound; // Assign flap sound in the Inspector.
    public AudioSource deathSound; // Assign death sound in the Inspector.

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

            // Play the flap sound when the mouse button is clicked.
            if (flapSound != null)
            {
                flapSound.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe")) // Adjust the tag to match your pipe objects.
        {
            // Play the death sound.
            if (deathSound != null)
            {
                deathSound.Play();
            }

            // Trigger the game over state.
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
