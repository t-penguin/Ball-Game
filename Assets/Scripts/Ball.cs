using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 position = transform.position;
        position.x = 2;
        transform.position = position;
        transform.localScale *= 2;
        rb.AddForce(new Vector2(5, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
