using UnityEngine;

[CreateAssetMenu(fileName = "HealAbility")]
public class Heal : Ability
{
    [SerializeField] float healAmount = 2f;
    [SerializeField] PlayerHealth playerHealth;

    public override void Initialize(Transform character)
    {
        base.Initialize(character);
        playerHealth = FindObjectOfType<PlayerHealth>();
        //cdParticles = mainCharacter.Find("Heal particle").GetComponent<ParticleSystem>();
    }

    public override void Trigger()
    {
        playerHealth.Heal(healAmount);
    }
}
