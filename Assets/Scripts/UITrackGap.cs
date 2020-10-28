using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrackGap : MonoBehaviour
{
    public UIController uIController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            uIController.firstTrackPlace = true;
        }
    }
}
