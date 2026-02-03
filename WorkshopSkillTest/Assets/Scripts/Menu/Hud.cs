using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [Header("Points")] 
    [SerializeField] private TextMeshProUGUI pointsText;

    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        updateTimerText();
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
