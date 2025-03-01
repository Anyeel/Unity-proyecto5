using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;

    void Start()
    {
        SetHealth();
        GameEvents.GameRestart.AddListener(SetHealth);
    }

    protected virtual void Update()
    {

    }

    public void TakeDamage(float damage, UnityEvent onHurtEvent = null)
    {
        if (IsDead())
            return;
        currentHealth -= damage;
        onHurtEvent?.Invoke();
        if (IsDead()) OnDeath();
    }

    void SetHealth()
    {
        currentHealth = maxHealth;
    }

    protected virtual bool IsDead()
    {
        return currentHealth <= 0;
    }

    protected virtual void OnDeath()
    {
        currentHealth = 0;
        if (gameObject.CompareTag("Enemy")) Destroy(gameObject);
    }
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth; 
    }

    public float HealthLeft
    {
        get => currentHealth / maxHealth;
    }
}