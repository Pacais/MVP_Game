using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingSquare : MonoBehaviour, IPointerDownHandler
{
    private TrainingController trainingController;
    private bool isInitialSquare = false;
    private RandomSpawn randomSpawn;

    public void SetTrainingController(TrainingController controller)
    {
        trainingController = controller;
    }

    public void SetAsInitialSquare()
    {
        isInitialSquare = true;
    }

    public void SetRandomSpawn(RandomSpawn spawn)
    {
        randomSpawn = spawn;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInitialSquare)
        {
            // Do nothing if it's an initial square
            return;
        }

        if (trainingController != null)
        {
            trainingController.OnSquareTouched();
        }

        if (randomSpawn != null)
        {
            randomSpawn.OnSquareTouched();
        }

        // Destroy the square
        Destroy(gameObject);
    }
}
