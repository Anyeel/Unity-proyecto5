using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootAbility")] 
public class Shoot : Ability { 
    [SerializeField] GameObject ProjectilePrefab; 
    [SerializeField] Transform spawnPoint; 
    public override void Initialize(Transform character)
    {
        base.Initialize(character);
        spawnPoint = mainCharacter.Find("Projectile Spawn Point");
    }
    public override void Trigger() 
    { 
        GameObject projectile = Instantiate(ProjectilePrefab, spawnPoint.position, mainCharacter.rotation);
    }

}
