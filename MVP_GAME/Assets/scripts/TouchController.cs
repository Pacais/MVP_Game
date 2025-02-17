using UnityEngine;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class TouchController : MonoBehaviour, IPointerDownHandler
{
    private Stopwatch stopwatch;
    private ReactionTestController reactionTestController;

    public void SetStopwatch(Stopwatch sw)
    {
        stopwatch = sw;
    }

    public void SetReactionTestController(ReactionTestController controller)
    {
        reactionTestController = controller;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("Game object clicked: " + gameObject.name);
        if (stopwatch != null && stopwatch.IsRunning)
        {
            stopwatch.Stop();
            long reactionTime = stopwatch.ElapsedMilliseconds;
            UnityEngine.Debug.Log("Reaction time: " + reactionTime + " ms");

            // Update the score with the reaction time
            if (reactionTestController != null)
            {
                reactionTestController.UpdateScore(reactionTime);
            }
        }

        // Destroy the game object
        Destroy(gameObject);
    }
}

