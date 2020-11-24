using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCentreController : MonoBehaviour
{
    public Transform reverseEdge;
    public Transform centre;
    public bool trainPassingTransform;

    void OnTriggerEnter(Collider other)
    {
        if (trainPassingTransform == true)
        {
            return;

        }
        if (other.CompareTag("Train"))
        {

            TrainController script = other.gameObject.GetComponent<TrainController>();

            script.previousTarget = centre;
            script.currentTarget = reverseEdge;
            trainPassingTransform = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            trainPassingTransform = false;
        }
    }
}
