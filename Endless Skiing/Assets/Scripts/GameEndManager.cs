using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText; // Sử dụng TextMeshPro nếu bạn đã chọn sử dụng TMP


    private void Start()
    {
        // Lấy điểm từ GameManager và hiển thị lên UI
        int score = GameManager.inst.GetScore();
        scoreText.text = "Your Score Was: " + score;
        int highScore = GameManager.inst.GetHighScore();
        highScoreText.text = "Your High Score Was: " + highScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // Chơi lại game
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("GameMenuScene"); // Quay lại menu chính
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
