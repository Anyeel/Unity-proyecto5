using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverText;
    private bool gameIsOver;

    void Start()
    {
        GameEvents.PlayerDied.AddListener(PlayerJustDied);
        GameEvents.GameRestart.AddListener(GameRestarted);
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
        {
            if (Input.GetKey(KeyCode.R))
            {
                GameEvents.GameRestart.Invoke();
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
        gameOverUI.SetActive(false);
        gameIsOver = false;
    }

    public bool GameIsOver
    {
        get { return gameIsOver; }
    }
}