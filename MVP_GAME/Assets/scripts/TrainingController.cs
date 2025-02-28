using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class TrainingController : MonoBehaviour
{
    public GameObject squarePrefab; // The prefab to spawn
    public TMP_Text squaresTouchedText; // Reference to the TextMeshPro component for squares touched
    public TMP_Text averageTimeText; // Reference to the TextMeshPro component for average time
    private Vector3[] positions = new Vector3[5]; // Array to hold the 5 fixed positions
    private List<GameObject> spawnedSquares = new List<GameObject>(); // List to hold the spawned squares

    private Stopwatch totalStopwatch;
    private Stopwatch touchStopwatch;
    private int squaresTouched = 0;
    private float totalTimeBetweenTouches = 0f;
    private bool initialSquaresHidden = false;

    void Start()
    {
        // Define the 5 fixed positions for a 1920x1080 resolution in landscape mode
        positions[0] = new Vector3(-1.8f, 4f, 0f); // Top-left (moved 0.2 towards center)
        positions[1] = new Vector3(1.8f, 4f, 0f); // Top-right (moved 0.2 outwards)
        positions[2] = new Vector3(0f, 0.4f, 0f); // Center
        positions[3] = new Vector3(-1.8f, -1.7f, 0f); // Bottom-left (moved 0.2 towards center)
        positions[4] = new Vector3(2.2f, -1.7f, 0f); // Bottom-right (moved 0.2 outwards)

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
            square.GetComponent<TrainingSquare>().SetAsInitialSquare();
            spawnedSquares.Add(square);
        }

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Hide all squares
        foreach (GameObject square in spawnedSquares)
        {
            square.SetActive(false);
        }

        initialSquaresHidden = true;

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
        if (!initialSquaresHidden)
        {
            return;
        }

        squaresTouched++;
        totalTimeBetweenTouches += touchStopwatch.ElapsedMilliseconds;
        touchStopwatch.Restart();

        // Print the values
        string squaresTouchedMessage = $"Squares Touched: {squaresTouched}";
        string averageTimeMessage = $"Time Between Touches: {(totalTimeBetweenTouches / squaresTouched)} ms";
        UnityEngine.Debug.Log(squaresTouchedMessage);
        UnityEngine.Debug.Log(averageTimeMessage);

        // Update the UI Text
        if (squaresTouchedText != null)
        {
            squaresTouchedText.text = squaresTouchedMessage;
        }
        if (averageTimeText != null)
        {
            averageTimeText.text = averageTimeMessage;
        }

        // Spawn the next square
        SpawnNextSquare();
    }
}

