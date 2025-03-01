
public class EnemyHealth : Health
{
    protected override void OnDeath()
    {
        base.OnDeath();
        GameEvents.EnemyDied.Invoke();
    }
}
