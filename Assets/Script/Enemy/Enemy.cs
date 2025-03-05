using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private Vector3 movementInput;
    private float speed;
    [SerializeField] float minSpeed = 3f;
    [SerializeField] float maxSpeed = 4f;
    [SerializeField] float damage = 10f;
    [SerializeField] float fleeingSpeed = 10f;
    bool gameIsOver;
    Transform mainCharacterTransform;

    void Start()
    {
        mainCharacterTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = Random.Range(minSpeed, maxSpeed);
        GameEvents.GameRestart.AddListener(GameRestarted);
        GameEvents.PlayerDied.AddListener(GameOver);
    }

    void Update()
    {
        Vector3 mainCharacterPosition = mainCharacterTransform.transform.position;

        movementInput = (mainCharacterPosition - transform.position);

        movementInput = movementInput.normalized;

        if (!gameIsOver)
        {
            transform.position += speed * movementInput * Time.deltaTime;
        }
        else if (gameIsOver)
        {
            transform.position += speed * movementInput * Time.deltaTime * -fleeingSpeed;
        }
    }

    void GameRestarted()
    {
        gameIsOver = false;
        Destroy(gameObject);
    }
    void GameOver()
    {
        gameIsOver = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
