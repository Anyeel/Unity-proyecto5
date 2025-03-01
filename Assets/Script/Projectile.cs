using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float maxDistance = 15f;
    [SerializeField] float damage = 5f;
    private Vector3 initialPosition;
    PlayerStats playerStats;

    void Start()
    {
        initialPosition = transform.position;
        playerStats = FindAnyObjectByType<PlayerStats>();
    }

    void Update()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * projectileSpeed;

        float distanceTraveled = Vector3.Distance(initialPosition, transform.position);

        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage * playerStats.Strength);
            Destroy(gameObject);
        }
    }
}
