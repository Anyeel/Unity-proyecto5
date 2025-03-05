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
        
        // Obtén la posición del ratón en la pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Convierte la posición del ratón en la pantalla a coordenadas del mundo
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0; // Asegúrate de que la posición Z sea 0 para un espacio 2D

        // Calcula la dirección hacia el ratón
        Vector3 direction = mousePosition - transform.position;

        // Calcula el ángulo en el que el personaje debe rotar para mirar al ratón
        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);

        // Aplica la rotación al personaje sin ajuste extra
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
