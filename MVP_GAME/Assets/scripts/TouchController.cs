using UnityEngine;
using UnityEngine.EventSystems;
using System.Diagnostics;
using Unity.VisualScripting;

public class TouchController : MonoBehaviour, IPointerDownHandler
{
    private Stopwatch stopwatch;

    public void SetStopwatch(Stopwatch sw)
    {
        stopwatch = sw;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("Game object clicked: " + gameObject.name);
        if (stopwatch != null && stopwatch.IsRunning)
        {
            stopwatch.Stop();
            UnityEngine.Debug.Log("Reaction time: " + stopwatch.ElapsedMilliseconds + " ms");
        }

        Destroy(gameObject);
    }
}