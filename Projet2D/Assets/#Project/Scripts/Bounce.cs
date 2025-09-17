using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bounce : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 v2 = transform.position;
        transform.position = v2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(transform.up * 500);
    }
}
