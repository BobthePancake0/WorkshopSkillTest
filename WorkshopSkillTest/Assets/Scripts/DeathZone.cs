using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField] GameObject gameoverScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;
        
        if (other.tag == "Player")
        {
            Debug.Log("Player passed through DEATH");
            gameoverScreen.SetActive(true);
            GameManager.Instance.GameOver();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
