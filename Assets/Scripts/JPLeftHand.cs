using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPLeftHand : MonoBehaviour
{
    private bool touching = false;
    public GameObject gameObject;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Pickup")
        {
            touching = true;
            //set the color of the object to red

            SetColour otherColor = other.gameObject.GetComponent<SetColour>();
            otherColor.SetRed();

            //check if i have pinched OR if the controller button has gone down while i have gone over

            //pickup the object by turning off its rigidbody and then moving it to the position of the hand

        }
        else
        {
            SetColour otherColor = other.gameObject.GetComponent<SetColour>();
            otherColor.SetGreen();
            touching = false;
        }
    }

    //on exit we will set the color back to normal
    private void OnTriggerExit(Collider other)
    {
        SetColour otherColor = other.gameObject.GetComponent<SetColour>();
        otherColor.SetBlack();
        touching = false;
    }

    /*
     if(indexFingerPinchStrength == 1)
        {
            pickupObject.transform.parent = transform;
            if (pickupObject.GetComponent<Rigidbody>())
            {
                Rigidbody rb = pickupObject.GetComponent<Rigidbody>();
    rb.isKinematic = true;
                rb.useGravity = false;
                //rb.velocity = OVRHand.
            }
        }
        */
}
