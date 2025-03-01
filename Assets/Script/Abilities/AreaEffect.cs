using UnityEngine;
using static UnityEngine.ParticleSystem;

[CreateAssetMenu(fileName = "AreaAbility")]
public class AreaEffect : Ability
{
    [SerializeField] GameObject AreaPrefab;
    [SerializeField] float areaRadius;
    [SerializeField] LayerMask enemyLayer;
    Collider2D[] hitEnemies;
    Area area;

    public override void Initialize(Transform character)
    {
        base.Initialize(character);
    }

    public override void Trigger()
    {
        GameObject Area = Instantiate(AreaPrefab, mainCharacter.position, Quaternion.identity);
        area = FindAnyObjectByType<Area>();
        hitEnemies = Physics2D.OverlapCircleAll(new Vector2(mainCharacter.position.x, mainCharacter.position.y), areaRadius, enemyLayer);

        if (hitEnemies.Length == 0)
        {
            CoroutineRunner.Instance.StartCoroutine(area.FadeArea());

            return;
        }

        float shortestDistance = CalculateSqrDistance(0);
        int closestEnemyIndex = 0;
        for (int x = 1; x < hitEnemies.Length; x++)
        {
            float distanceToCurrentEnemy = CalculateSqrDistance(x);
            if (distanceToCurrentEnemy < shortestDistance)
            {
                shortestDistance = distanceToCurrentEnemy;
                closestEnemyIndex = x;
            }
        }

        GameObject.Destroy(hitEnemies[closestEnemyIndex].gameObject);
        CoroutineRunner.Instance.StartCoroutine(area.FadeArea());
    }

    float CalculateSqrDistance(int index)
    {
        return hitEnemies[index].transform.position.x * hitEnemies[index].transform.position.x + hitEnemies[index].transform.position.y * hitEnemies[index].transform.position.y;
    }
}
