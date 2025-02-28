using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnArea = new Vector3(10, 0, 10);
    public float spawnInterval = 2.0f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-2f, 2f),  // x range
            Random.Range(-3.2f, 4f),  // y range
            0  // z coordinate (assuming 2D, set to 0)
        );

        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }

   


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objectToSpawn)
        {
            Destroy(collision.gameObject);
            SpawnObject();
        }
    }
}