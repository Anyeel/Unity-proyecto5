using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.TextCore.Text;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float regenerationRate = 1f;
    [SerializeField] float improveRegenerationRate = 1f;
    [SerializeField] float strength = 1f;
    [SerializeField] float improveStrength = 2f;
    [SerializeField] float improvedStrengthTime = 5f;
    [SerializeField] ParticleSystem strengthParticles;
    private bool isStrengthImproved = false;
    private float currentStrength;

    void Start()
    {
        currentStrength = strength;
    }

    public float Strength
    {
        get { return currentStrength; }
    }

    public float RegenerationRate
    {
        get { return regenerationRate; }
    }

    public float ImproveRegenerationRate
    {
        get { return improveRegenerationRate; }
    }

    public void TriggerStrengthImprovement()
    {
        if (!isStrengthImproved)
        {
            StartCoroutine(TemporaryStrengthBoost());
        }
    }

    private IEnumerator TemporaryStrengthBoost()
    {
        isStrengthImproved = true;
        currentStrength = improveStrength;
        strengthParticles.Play();
        yield return new WaitForSeconds(improvedStrengthTime);
        currentStrength = strength;
        isStrengthImproved = false;
        strengthParticles.Stop();
    }
}


