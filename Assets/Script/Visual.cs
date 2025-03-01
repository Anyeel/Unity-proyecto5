using UnityEngine;

public class Visual : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Gradient bodyColorGradient;
    PlayerHealth health;
    EnemyHealth enemy;

    void Start()
    {
        health = Object.FindAnyObjectByType<PlayerHealth>();
        enemy = gameObject.GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (gameObject.CompareTag("Player")) spriteRenderer.color = bodyColorGradient.Evaluate(health.HealthLeft);
        if (gameObject.CompareTag("Enemy")) spriteRenderer.color = bodyColorGradient.Evaluate(enemy.HealthLeft);
    }
}