using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTrackGap2 : MonoBehaviour
{
    public UIController uIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            uIController.secondTrackPlace = true;
        }
    }
}
