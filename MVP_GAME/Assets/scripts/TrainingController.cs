using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.EventSystems;

public class TrainingController : MonoBehaviour
{
    public GameObject squarePrefab; // The prefab to spawn
    private Vector3[] positions = new Vector3[5]; // Array to hold the 5 fixed positions
    private List<GameObject> spawnedSquares = new List<GameObject>(); // List to hold the spawned squares

    private Stopwatch totalStopwatch;
    private Stopwatch touchStopwatch;
    private int squaresTouched = 0;
    private float totalTimeBetweenTouches = 0f;

    void Start()
    {
        // Define the 5 fixed positions for a 1920x1080 resolution in landscape mode
        positions[0] = new Vector3(-2f, 4f, 0f); // Top-left
        positions[1] = new Vector3(2f, 4f, 0f); // Top-right
        positions[2] = new Vector3(0f, 0f, 0f); // Center
        positions[3] = new Vector3(-2f, -4f, 0f); // Bottom-left
        positions[4] = new Vector3(2f, -4f, 0f); // Bottom-right

        totalStopwatch = new Stopwatch();
        touchStopwatch = new Stopwatch();
        StartCoroutine(StartTraining());
    }

    IEnumerator StartTraining()
    {
        // Spawn all squares at the beginning
        foreach (Vector3 position in positions)
        {
            GameObject square = Instantiate(squarePrefab, position, Quaternion.identity);
            spawnedSquares.Add(square);
        }

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Hide all squares
        foreach (GameObject square in spawnedSquares)
        {
            square.SetActive(false);
        }

        // Start the training
        totalStopwatch.Start();
        touchStopwatch.Start();
        SpawnNextSquare();
    }

    void SpawnNextSquare()
    {
        // Spawn a square at a random position
        int randomIndex = Random.Range(0, positions.Length);
        GameObject square = Instantiate(squarePrefab, positions[randomIndex], Quaternion.identity);
        square.GetComponent<TrainingSquare>().SetTrainingController(this);
        square.SetActive(true);
    }

    public void OnSquareTouched()
    {
        squaresTouched++;
        totalTimeBetweenTouches += touchStopwatch.ElapsedMilliseconds;
        touchStopwatch.Restart();

        // Print the values
        UnityEngine.Debug.Log("Total Time: " + totalStopwatch.ElapsedMilliseconds + " ms");
        UnityEngine.Debug.Log("Squares Touched: " + squaresTouched);
        UnityEngine.Debug.Log("Average Time Between Touches: " + (totalTimeBetweenTouches / squaresTouched) + " ms");

        // Spawn the next square
        SpawnNextSquare();
    }
}



