using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public bool isHeld; // a bool for if the track piece is being held or not.

    /// <summary>
    /// Function to handle different collisions with the side
    /// this script is attached to
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the object colliding with us has the tag player
        {
            isHeld = true; // change the bool for isHeld on the Track Controller Script to true
        }
    }

    /// <summary>
    /// Function handling what to do with colliders exiting ours
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the collider leaving our has the tag player
        {
            isHeld = false; // set the isHeld bool to false in the Track Controller script
        }
    }
}
