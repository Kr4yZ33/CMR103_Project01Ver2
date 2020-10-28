using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSideController : MonoBehaviour
{
    public TrackController trackController; // reference to our Track Controller script
    Renderer r; // private reference to the renderer
    public bool openForTrack; // bool for if the side can take track or not
    public bool isConnected; // bool for if the side is connected to another side or not

    // Start is called before the first frame update
    void Start()
    {

        r = GetComponent<Renderer>(); // get the renderer of the object this script is attached to

        if (gameObject.CompareTag("TrackSideClosed")) // if the object this script is attached to has the tag NoTrackConnections
        {
            openForTrack = false; // set the bool for openForTrack to false
        }

        if (!gameObject.CompareTag("TrackSideClosed")) // if the object this script is attached to does not have the tag NoTrackConnections
        {
            openForTrack = true; // set the bool for openForTrack to true
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(trackController.isHeld == true)
        {
            isConnected = false;
        }
        
        if (isConnected == true) // if the bool for isConnected is true
        {
            r.material.color = Color.yellow; // set our object's colour to yellow
        }

        if (openForTrack == true && isConnected == false) // if the bool for openForTrack is true
        {
            r.material.color = Color.green; // set our object's colour to blue
        }

        if (openForTrack == false) // if the bool for openForTrack is false
        {
            r.material.color = Color.red; // set our object's colour to red
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Side collision");
        
        if (other.gameObject.CompareTag("TrackSideOpen")) // if the object colliding with us has the tag TrackTransformOpen
        {
            Debug.Log("Is Connected");
            isConnected = true; // Set the bool for isConnected to true
        }
    }
}
