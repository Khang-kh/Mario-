using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false); // Ẩn UI Game Over ban đầu
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0f; // Dừng thời gian
        gameOverUI.SetActive(true); // Hiển thị UI Game Over
    }

    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1f; // Tiếp tục thời gian
        SceneManager.LoadScene("Game"); // Tải lại cảnh hiện tại
    }
}
