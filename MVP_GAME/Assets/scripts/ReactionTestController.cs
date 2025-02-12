using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ReactionTestController : MonoBehaviour
{
    public GameObject[] gameObjects; // Array to hold the 3 game objects
    public GameObject newGameObject; // The new game object to spawn
    private float initialDelay = 1f; // Initial delay before starting the coroutine

    // Define the boundaries of the square
    private Vector3 squareMin = new Vector3(-2f, -2.5f, 0f); // Bottom-left corner of the square
    private Vector3 squareMax = new Vector3(1f, -0.5f, 0f); // Top-right corner of the square

    private Stopwatch stopwatch;

    void Start()
    {
        stopwatch = new Stopwatch();
        StartCoroutine(StartWithDelay());
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(HandleGameObjects());
    }

    IEnumerator HandleGameObjects()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false); // Make the game object disappear
            yield return new WaitForSeconds(Random.Range(1f, 3f)); // Wait for a random time between 1 and 3 seconds
        }

        // Generate random coordinates within the square boundaries
        float randomX = Random.Range(squareMin.x, squareMax.x);
        float randomY = Random.Range(squareMin.y, squareMax.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Spawn the new game object at the random position
        GameObject spawnedObject = Instantiate(newGameObject, randomPosition, Quaternion.identity);
        UnityEngine.Debug.Log("Spawned new game object at position: " + randomPosition);
        if (spawnedObject == null)
        {
            UnityEngine.Debug.LogError("Failed to instantiate new game object.");
            yield break;
        }

        TouchController touchController = spawnedObject.GetComponent<TouchController>();
        if (touchController != null)
        {
            touchController.SetStopwatch(stopwatch);
            stopwatch.Start();
            UnityEngine.Debug.Log("Stopwatch started.");
        }
        else
        {
            UnityEngine.Debug.LogError("TouchController component not found on the spawned object.");
        }
    }
}
