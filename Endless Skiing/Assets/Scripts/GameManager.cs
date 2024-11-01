using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

    // Khai báo biến cho điểm cao nhất
    private int highScore;

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public int GetScore()
    {
        return score;
    }

    private void Awake ()
    {
        inst = this;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void CheckAndSaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Lưu thay đổi
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }

    private void Start () {

	}

	private void Update () {
	
	}
}