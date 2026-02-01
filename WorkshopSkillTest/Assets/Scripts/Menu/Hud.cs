using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI pointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePointScore()
    {
        pointsText.text = ScoreManager.Instance.getPoints().ToString();
    }
}
