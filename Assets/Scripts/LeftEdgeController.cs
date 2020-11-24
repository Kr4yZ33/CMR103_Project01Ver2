using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEdgeController : MonoBehaviour
{

    public HapticsController hapticsController;
    public bool trainPassingTransform;

    public Transform closestEdge;
    public Transform right;
    public Transform left;

    void OnTriggerEnter(Collider other)
    {
        if (trainPassingTransform == true)
        {
            return;

        }
        if (other.CompareTag("Train"))
        {
            TrainController script = other.gameObject.GetComponent<TrainController>();

            if (script.previousTarget != right)
            {
                script.previousTarget = left;
                script.currentTarget = right;
                trainPassingTransform = true;
            }
            if (script.previousTarget == right)
            {
                script.previousTarget = left;
                script.currentTarget = closestEdge;
                trainPassingTransform = true;
            }
        }

        if (other.CompareTag("TrackSideOpen"))
        {
            closestEdge = other.transform;
            hapticsController.trackConnected = true;
            hapticsController.PlayTrackConnectionClip();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Train"))
        {
            trainPassingTransform = false;
        }
        if (other.CompareTag("TrackSideOpen"))
        {
            closestEdge = null;
            hapticsController.trackConnected = false;
            hapticsController.trackConnectClipPlayed = false;
        }

    }
}
