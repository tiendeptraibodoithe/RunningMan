using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI
using UnityEngine.SceneManagement; // Để quản lý scene

public class PlayerFall : MonoBehaviour
{
    public float fallTimeLimit = 1f; // Thời gian rơi trước khi Game Over
    private float fallTimer = 0f;     // Bộ đếm thời gian rơi
    private bool isFalling = false;   // Trạng thái rơi của nhân vật
    private Rigidbody2D rb;           // Rigidbody của nhân vật

    public GameObject gameOverPanel;  // Game Over Panel

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody của nhân vật
        gameOverPanel.SetActive(false);    // Ẩn UI Game Over lúc đầu
    }

    private void Update()
    {
        // Kiểm tra vận tốc theo chiều dọc (rơi tự do)
        if (rb.velocity.y < 0)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
            fallTimer = 0f;  // Reset bộ đếm nếu không rơi
        }

        // Nếu nhân vật rơi, bắt đầu đếm thời gian
        if (isFalling)
        {
            fallTimer += Time.deltaTime;

            // Nếu rơi quá 1 giây, hiển thị Game Over
            if (fallTimer >= fallTimeLimit)
            {
                ShowGameOver();
            }
        }
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true); // Hiển thị UI Game Over
        Time.timeScale = 0;            // Dừng game lại
    }

    // Hàm để khởi động lại game
    public void RestartGame()
    {
        Time.timeScale = 1; // Reset timeScale về 1
        Debug.Log("Time scale reset to: " + Time.timeScale);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load lại scene hiện tại
    }
}

