using UnityEngine;

[CreateAssetMenu(fileName = "ImproveStrength")]
public class ImproveStrength : Ability
{

    public override void Initialize(Transform character)
    {
        base.Initialize(character);
        playerStats = character.GetComponent<PlayerStats>();
    }

    public override void Trigger()
    {
        playerStats.TriggerStrengthImprovement();
    }

    protected override void GameOver()
    {
        base.GameOver();
    }
}
