
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] public bool improveRegeneration = false;
    protected override void OnDeath()
    {
        base.OnDeath();
        GameEvents.PlayerDied.Invoke();
    }
    protected override void Update() 
    {
        base.Update();
        PassiveRegeneration(Time.deltaTime * playerStats.RegenerationRate);
    }

    private void PassiveRegeneration(float regenerationAmount)
    {
        if (!IsDead() && currentHealth < maxHealth) 
        { 
            if (improveRegeneration)
            {
                currentHealth += regenerationAmount * playerStats.ImproveRegenerationRate;
            }
            else
            {
                currentHealth += regenerationAmount;
            }

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
