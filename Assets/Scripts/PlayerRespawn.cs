using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform playerRespawnTransform; // reference to the respawn transform

    /// <summary>
    /// on trigger enter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn")) // if this thing colliding with us is tagged Respawn
        {
            gameObject.transform.position = playerRespawnTransform.transform.position; // set the transform position of this game object to the respwan transform
            gameObject.transform.rotation = playerRespawnTransform.transform.rotation; // set the transform rotation of this game object to the respwan rotation
        }
    }
}
