using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Box : MonoBehaviour
{

    [SerializeField] private int pointValue = 1; 

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
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.Instance.addPoints(pointValue);
        }
    }




}
