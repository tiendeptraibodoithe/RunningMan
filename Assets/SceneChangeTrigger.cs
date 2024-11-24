using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    // Tham chiếu đến scene hiện tại
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem collider có phải là player không
        if (other.CompareTag("Player")) // Đảm bảo player có tag là "Player"
        {
            // Lấy chỉ số scene hiện tại
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Tính chỉ số scene tiếp theo
            int nextSceneIndex = currentSceneIndex + 1;

            // Kiểm tra xem scene tiếp theo có tồn tại không
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex); // Chuyển đến scene tiếp theo
            }
            else
            {
                Debug.Log("Đã đến scene cuối cùng, không có scene tiếp theo."); // Thông báo nếu không còn scene nào
            }
        }
    }
}

