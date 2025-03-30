using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    private Timer _lifeTimer;
    [SerializeField] private float _lifetime;
    [SerializeField] private int _bounces;
    [SerializeField] private int _maxBounces;

    private Rigidbody2D _rb;
    private bool _increaseSpeed;

    // Sets the ball's size and moves it in a random direction at a random speed
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        float scalar = Random.Range(0.5f, 2f);
        transform.localScale *= scalar;
        _rb.mass *= scalar;

        _maxBounces = Random.Range(20, 41);

        float angle = Random.Range(0, 2 * Mathf.PI);
        float magnitude = Random.Range(12f, 20f);
        float x = Mathf.Cos(angle) * magnitude;
        float y = Mathf.Sin(angle) * magnitude;
        _rb.AddForce(new Vector2(x, y));

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        sr.color = new Color(r, g, b);

        _lifeTimer = gameObject.AddComponent<Timer>();
        _lifeTimer.Duration = _lifetime;
        _lifeTimer.Run();

        _increaseSpeed = false;
    }

    private void Update()
    {
        if (_increaseSpeed)
            _rb.linearVelocity *= 1.01f;

        if (_lifeTimer.Finished)
            Destroy(gameObject);
    }

    // Counts the number of bounces and destroys the ball after maxBounces
    private void OnCollisionEnter2D(Collision2D other)
    {
        _bounces++;

        if (_bounces >= _maxBounces)
            Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Hovering");
        _increaseSpeed = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("Stopped Hovering");
        _increaseSpeed = false;
    }
}
