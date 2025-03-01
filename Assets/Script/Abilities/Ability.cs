using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : ScriptableObject
{
    [SerializeField] protected string abilityName;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected Transform mainCharacter;
    protected PlayerStats playerStats;
    protected GameOver gameOver;
    protected float elapsedTime;
    protected bool cooldown = false;

    public virtual void Initialize(Transform character)
    { 
        mainCharacter = character;
        playerStats = mainCharacter.GetComponent<PlayerStats>();
        gameOver = Object.FindAnyObjectByType<GameOver>();
        GameEvents.PlayerDied.AddListener(GameOver);
    }

    public IEnumerator Cooldown()
    { 
        elapsedTime = 0;
        cooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
    }

    protected virtual void GameOver()
    {
        cooldown = false;
    }

    public abstract void Trigger();    

    public bool GetCooldown
    {
        get { return cooldown; }
    }

    public float SetElapsedTime
    {
        set { elapsedTime = value; }
    }

    public float GetElapsedTime
    {
        get { return elapsedTime; }
    }

    public float GetCooldownTime
    {
        get { return cooldownTime; }
    }
}
