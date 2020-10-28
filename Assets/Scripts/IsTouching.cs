using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouching : MonoBehaviour
{
    public JPRightHand jPRightHand;
    public bool isTouchingGrabObject = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            isTouchingGrabObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            isTouchingGrabObject = false;
        }
    }
}
