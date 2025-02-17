using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class TrainingSquare : MonoBehaviour, IPointerDownHandler
{
    private TrainingController trainingController;

    public void SetTrainingController(TrainingController controller)
    {
        trainingController = controller;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (trainingController != null)
        {
            trainingController.OnSquareTouched();
        }

        // Destroy the square
        Destroy(gameObject);
    }
}
