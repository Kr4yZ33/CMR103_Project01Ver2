using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPRightHandXR : MonoBehaviour
{
    public bool firstTouch;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) // if the object colliding with us has the tag Pickup
        {
            firstTouch = true; // change the bool for isTouching to true
        }
    }
}
