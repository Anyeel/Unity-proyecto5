using UnityEngine;

public class Visual : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Gradient bodyColorGradient;
    Health health; 

    void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        spriteRenderer.color = bodyColorGradient.Evaluate(health.HealthLeft);
    }
}
