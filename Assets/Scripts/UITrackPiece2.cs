using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrackPiece2 : MonoBehaviour
{
    public UIController uIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uIController.secondTrackGrab = true;
        }
    }
}
