using System;
using System.Collections;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Box")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float lifetime = 10f;
    [SerializeField] private float maxBoxVelocity = 30f;
    [SerializeField] private float minBoxVelocity = 30f;
    [SerializeField] private int maxBoxSize = 5;
    [SerializeField] private int minBoxSize = 1;

    [Header("Spawning")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float maxSpawnRate = 10f;
    [SerializeField] private float minSpawnRate = 5;
    
    private float spawnRate;
    private float coolDown = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnRate = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver())
        {
        
            if (coolDown >= maxSpawnRate)
            {
                FireBox();
                spawnRate = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
                coolDown = 0;
            }
            else
                coolDown += 0.1f;
                
        }
    }


    private void FireBox()
    {

        Vector3 pos = spawnPoint.position;
        // Sets the Box Position randomly within the range of the spawnpoint
        pos.z += UnityEngine.Random.Range(-spawnPoint.localScale.z / 2, spawnPoint.localScale.z / 2);

        GameObject box = Instantiate(projectile, pos, Quaternion.identity);

        // Sets the boxes size randomly
        box.transform.localScale *= UnityEngine.Random.Range(Mathf.Clamp(minBoxSize, 1, maxBoxSize), maxBoxSize);

        float velocity = UnityEngine.Random.Range(minBoxVelocity, maxBoxVelocity);
        box.GetComponent<Rigidbody>().AddForce(spawnPoint.forward.normalized * velocity, ForceMode.Impulse);

        StartCoroutine(DestroyBoxAfterTime(box, lifetime));

        Debug.Log("Spawned Box");
    }


    private IEnumerator DestroyBoxAfterTime(GameObject box, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(box);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(spawnPoint.position, spawnPoint.localScale);
    }
    
    

}
