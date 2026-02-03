using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI points;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        points.text = ScoreManager.Instance.getPoints().ToString();
    }

    
    void OnBecameVisible()
    {
        points.text = ScoreManager.Instance.getPoints().ToString();
    }
}
