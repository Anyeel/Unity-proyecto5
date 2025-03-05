using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverText;
    private bool gameIsOver;

    void Start()
    {
        GameEvents.PlayerDied.AddListener(PlayerJustDied);
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
        {
            if (Input.GetKey(KeyCode.R))
            {
                GameRestarted();
            }
        }
    }

    private void PlayerJustDied()
    {
        gameOverText.text = "Has perdido, presiona R para reiniciar";
        gameOverUI.SetActive(true);
        gameIsOver = true;
    }

    void GameRestarted()
    {
        GameEvents.GameRestart.Invoke();
        gameOverUI.SetActive(false);
        gameIsOver = false;
    }
}