using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private bool gameOver = false;


    void Update()
    {


    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        print("asdasda");
    }

    public void GameOver()
    {

        if (gameOver == false)
        {
            gameOver = true;

            Invoke("RestartLevel", 5f);
        }

    }

    public bool isGameOver()
    {
        return gameOver;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
        ScoreManager.Instance.ResetPoints();
    }
}
