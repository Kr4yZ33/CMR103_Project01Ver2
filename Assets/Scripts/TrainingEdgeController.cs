using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEdgeController : MonoBehaviour
{
    public LeftEdgeController leftEdgeController;
    public RightEdgeController rightEdgeController;
    public TrainController trainController;

    private void FixedUpdate()
    {
        if(leftEdgeController.closestEdge != null)
        {
            trainController.trainingLeft = true;
        }

        if(rightEdgeController.closestEdge != null)
        {
            trainController.trainingRight = true;
        }
    }
}
