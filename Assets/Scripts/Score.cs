using UnityEngine;
using UnityEngine.UI;

public class gameObject : MonoBehaviour
{
    public Text scoreText;  // Kết nối với đối tượng Text trong Unity để hiển thị điểm
    private int score = 0;   // Biến để lưu điểm

    void Start()
    {
        UpdateScoreText();  // Gọi hàm để cập nhật hiển thị điểm khi bắt đầu game
    }

    void UpdateScoreText()
    {
        // Cập nhật hiển thị điểm trên Text UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void IncreaseScore(int gameObject)
    {
        score += gameObject;  // Tăng điểm theo số lượng được truyền vào hàm
        UpdateScoreText();  // Cập nhật hiển thị điểm
    }
}
