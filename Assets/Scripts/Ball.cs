using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _maxBounces;
    [SerializeField] private int _bounces;

    // Sets the ball's size and moves it in a random direction at a random speed
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float scalar = Random.Range(0.5f, 2f);
        transform.localScale *= scalar;
        rb.mass *= scalar;
        float angle = Random.Range(0, 2 * Mathf.PI);
        float magnitude = Random.Range(12f, 20f);
        float x = Mathf.Cos(angle) * magnitude;
        float y = Mathf.Sin(angle) * magnitude;
        rb.AddForce(new Vector2(x, y));
    }

    // Counts the number of bounces and destroys the ball after maxBounces
    private void OnCollisionEnter2D(Collision2D other)
    {
        _bounces++;

        if (_bounces >= _maxBounces)
            Destroy(gameObject);
    }
}
