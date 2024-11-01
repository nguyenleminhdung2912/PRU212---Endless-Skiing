using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Tham chiếu tới UI Pause Menu
    private bool isPaused = false;

    void Update()
    {
        // Kiểm tra xem phím Esc có được nhấn không để tạm dừng
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Ẩn Pause Menu
        Time.timeScale = 1f; // Đặt thời gian trở lại bình thường
        isPaused = false; // Đặt trạng thái là không tạm dừng
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Hiện Pause Menu
        Time.timeScale = 0f; // Tạm dừng thời gian
        isPaused = true; // Đặt trạng thái là tạm dừng
    }

    public void Quit()
    {
        // Quay về menu chính hoặc thoát game
        Application.Quit(); // Dùng để thoát game khi build
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("GameMenuScene"); // Đổi tên scene nếu cần
    }
}
