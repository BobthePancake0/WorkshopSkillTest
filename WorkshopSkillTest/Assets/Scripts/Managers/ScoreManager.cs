using UnityEngine;

public  class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance {get; private set;}
    private int totalPoints = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void addPoints(int pointValue)
    {
        totalPoints += pointValue;
        Debug.Log(totalPoints);
    }

    public int getPoints()
    {
        return totalPoints;
    }

}
