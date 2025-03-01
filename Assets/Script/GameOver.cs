using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] RestartGame restartGame;
    private bool gameIsOver;

    void Start()
    {
        GameEvents.PlayerDied.AddListener(PlayerJustDied);
        GameEvents.GameRestart.AddListener(GameRestarted);
        gameIsOver = false;
    }

    private void PlayerJustDied()
    {
        gameOverText.text = "Has perdido, presiona R para reiniciar";
        gameOverUI.SetActive(true);
        restartGame.enabled = true;
        gameIsOver = true;
    }

    void GameRestarted()
    {
        gameOverUI.SetActive(false);
        restartGame.enabled = false;
        gameIsOver = false;
    }

    public bool GameIsOver
    {
        get { return gameIsOver; }
    }
}