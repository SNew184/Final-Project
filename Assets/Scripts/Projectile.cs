using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null && rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Die();
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}