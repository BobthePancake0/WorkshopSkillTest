using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [Header("Points")] 
    [SerializeField] private TextMeshProUGUI pointsText;

    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    [SerializeField] private GameObject gameoverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsText.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver())
        {

            if (remainingTime <= 0)
            {
                gameoverScreen.SetActive(true);
                GameManager.Instance.GameOver();
            }

            updatePointScore();
            updateTimerText();
        }
    }

    public void updatePointScore()
    {
        pointsText.text = ScoreManager.Instance.getPoints().ToString();
    }

    public void updateTimerText()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
