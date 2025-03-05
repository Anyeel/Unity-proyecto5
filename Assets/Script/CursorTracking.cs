using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    bool gameIsOver;

    void Start()
    {
        GameEvents.PlayerDied.AddListener(GameOver);
        GameEvents.GameRestart.AddListener(GameRestart);
    }

    void Update()
    {
        if (gameIsOver) return;
        
        // Obt�n la posici�n del rat�n en la pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Convierte la posici�n del rat�n en la pantalla a coordenadas del mundo
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0; // Aseg�rate de que la posici�n Z sea 0 para un espacio 2D

        // Calcula la direcci�n hacia el rat�n
        Vector3 direction = mousePosition - transform.position;

        // Calcula el �ngulo en el que el personaje debe rotar para mirar al rat�n
        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);

        // Aplica la rotaci�n al personaje sin ajuste extra
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void GameOver()
    { 
        gameIsOver = true; 
    } 
    void GameRestart() 
    { 
        gameIsOver = false; 
    }
}
