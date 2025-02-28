using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnArea = new Vector3(10, 0, 10);
    public float spawnInterval = 2.0f;
    public TMP_Text squaresTouchedText; // Reference to the TextMeshPro component for squares touched

    private float timer;
    private int squaresTouched = 0;

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

        // Update the UI Text with the number of squares touched
        if (squaresTouchedText != null)
        {
            squaresTouchedText.text = $"Squares Touched: {squaresTouched}";
        }
    }

    void SpawnObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-2f, 2f),  // x range
            Random.Range(-3.2f, 4f),  // y range
            0  // z coordinate (assuming 2D, set to 0)
        );

        GameObject square = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        square.GetComponent<TrainingSquare>().SetRandomSpawn(this);
    }

    public void OnSquareTouched()
    {
        squaresTouched++;

        // Update the UI Text
        if (squaresTouchedText != null)
        {
            squaresTouchedText.text = $"Squares Touched: {squaresTouched}";
        }

        // Spawn the next square
        SpawnObject();
    }
}