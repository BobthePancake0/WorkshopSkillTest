using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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




}
