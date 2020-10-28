using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPRightHand : OVRGrabber //NOTE the OVRGrabber is NOT Monobehaviour
{
    public IsTouching isTouching;

    public void PickupObject()
    {
        if(isTouching.isTouchingGrabObject == true)
        {
            GrabBegin();
        }
        
    }

    public void ReleaseObject()
    {
        GrabEnd();
    }
}
