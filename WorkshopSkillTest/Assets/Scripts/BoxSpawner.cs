using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float boxVelocity = 30f;

    [SerializeField] private float spawnRate = 2f;

    private float coolDown = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coolDown >= spawnRate)
        {
            FireBox();
            coolDown = 0f;
        }
        else
            coolDown += 0.1f;
    }


    private void FireBox()
    {
        GameObject box = Instantiate(projectile, spawnPoint.position, Quaternion.identity);

        box.GetComponent<Rigidbody>().AddForce(spawnPoint.forward.normalized * boxVelocity, ForceMode.Impulse);

        Debug.Log("Spawned Box");
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, spawnPoint.localScale);
    }
    

}
