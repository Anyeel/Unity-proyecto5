using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] Ability[] abilities;
    [SerializeField] Image[] cooldownIcons;
    [SerializeField] Vector3 selectedScale = new Vector3(1f, 1f, 1f);
    [SerializeField] Vector3 defaultScale = new Vector3(0.8f, 0.8f, 0.8f);
    [SerializeField] ParticleSystem cdParticles;
    [SerializeField] Transform mainCharacterTransform;
    private int activePosition;
    bool gameIsOver;

    void Start()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            abilities[i].Initialize(transform);
        }
        activePosition = 1;
        UpdateCooldownIcons();
        GameEvents.GameRestart.AddListener(GameRestarted);
        GameEvents.PlayerDied.AddListener(GameOver);
    }

    void Update()
    {
        if (gameIsOver) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activePosition = 0;
            UpdateCooldownIcons();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activePosition = 1;
            UpdateCooldownIcons();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activePosition = 2;
            UpdateCooldownIcons();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activePosition = 3;
            UpdateCooldownIcons();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            activePosition = 4;
            UpdateCooldownIcons();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            activePosition = 5;
            UpdateCooldownIcons();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!abilities[activePosition].GetCooldown)
            {
                StartCoroutine(abilities[activePosition].Cooldown());
                abilities[activePosition].Trigger();
            }
            else cdParticles.Play();
        }

        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i].GetCooldown)
            {
                abilities[i].SetElapsedTime = abilities[i].GetElapsedTime + Time.deltaTime;
                cooldownIcons[i].fillAmount = abilities[i].GetElapsedTime / abilities[i].GetCooldownTime;
            }
        }
    }

    void GameRestarted()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            cooldownIcons[i].fillAmount = 1f;
        }
        gameIsOver = false;
    }

    void GameOver()
    {
        gameIsOver = true;
    }

    void UpdateCooldownIcons()
    {
        for (int i = 0; i < cooldownIcons.Length; i++)
        {
            if (i == activePosition)
            {
                cooldownIcons[i].transform.localScale = selectedScale;
            }
            else
            {
                cooldownIcons[i].transform.localScale = defaultScale;
            }
        }
    }
}
