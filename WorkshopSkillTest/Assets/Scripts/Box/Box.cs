using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField] private int pointValue = 1; 

    //[SerializeField] private float maxDistance = 5f;

    // private Vector3 origin;
    // private Vector3 direction;

    // private RaycastHit hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // origin = transform.position;
        // direction = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfPlayerAbove();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.Instance.addPoints(pointValue);
        }
    }

    // void CheckIfPlayerAbove()
    // {
        

        

    //     if (Physics.Raycast(origin, direction, out hit, maxDistance))
    //     {
    //         if (hit.collider.gameObject.tag == "Player")
    //         {
    //             Debug.Log("Player jumped over the object!");
    //             ScoreManager.Instance.addPoints(pointValue);
    //         }
    //     }
    // }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawRay(origin, direction * maxDistance);
    // }
}
