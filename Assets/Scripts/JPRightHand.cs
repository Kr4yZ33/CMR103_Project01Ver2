using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPRightHand : OVRGrabber //NOTE the OVRGrabber is NOT Monobehaviour
{
    public JPColourChange theCube; //this is just the cube which I move and change color
    public Rotate rotateObject; //this is the script reference to rotate the cube in the distance

    // Start is called before the first frame update
    protected override void Start() //Override becasue not using monobehaviour now
    {
        base.Start(); //So we call the super Start or base Start in this case
    }

    // Update is called once per frame
    public override void Update() //again need to override
    {
        var hand = GetComponent<OVRHand>(); //store our hand
        checkIfPinchingObject(hand); //Im passing hand here as an argument to the method im calling (its a little cleaner)
    }
    /// <summary>
    /// This method gets the index finger pinch and then grabs the object
    /// if we are not pinching then we let go
    /// I DONT HAVE GRAVITY ON MY OBJECTS BECASUE THEY EXIST IN SPACE AND WILL SNAP TO A GRID (Hopefully)
    /// </summary>
    /// <param name="hand"> This passes the hand compnent from update into this function</param>
    public void checkIfPinchingObject(OVRHand hand)
    {
        //store whether finger is touching or not
        bool isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (isIndexFingerPinching) //check if pinching finger and if so (if within collider range) pickup object
        {
            //is pinching., do something
            //theCube.SetGreen(); //ive commented out as we do not need this
            //rotateObject.setRotation(2); //and this
            GrabBegin();


        }
        else //let go or we are too far away
        {
            //not pinching
            //theCube.SetRed(); //again not needed
            GrabEnd();
            //at this stage we can start using vector 3 and euler angles to throw things
        }
    }
}
