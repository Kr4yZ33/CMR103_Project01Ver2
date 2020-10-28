using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrackPiece : MonoBehaviour
{
    public UIController uIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uIController.firstTrackGrab = true;
        }
    }
}
