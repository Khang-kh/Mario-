using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        // Initialize the GameManager instance
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); // Destroy the coin object
            audioManager.PlayCoinSound(); // Play coin sound from AudioManager
            gameManager.AddScore(10); 

        }
        else if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
