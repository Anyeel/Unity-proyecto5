using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ImproveHealing")]
public class ImprovePassiveHealing : Ability
{
    [SerializeField] float improvedRegenerationTime = 2f;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] ParticleSystem particles;

    public override void Initialize(Transform character)
    {
        base.Initialize(character);
        playerHealth = FindObjectOfType<PlayerHealth>();
        particles = mainCharacter.Find("Heal particle").GetComponent<ParticleSystem>();
    }

    public override void Trigger()
    {
        playerHealth.improveRegeneration = true;
        particles.Play();
        CoroutineRunner.Instance.StartCoroutine(ResetImprovedRegeneration());
    }

    public IEnumerator ResetImprovedRegeneration()
    {
        yield return new WaitForSeconds(improvedRegenerationTime);
        particles.Stop();
        playerHealth.improveRegeneration = false;
    }

    protected override void GameOver()
    {
        base.GameOver();
        particles.Stop();
        playerHealth.improveRegeneration = false;
    }
}

