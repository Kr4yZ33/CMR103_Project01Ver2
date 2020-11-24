using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform playerRespawnTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            gameObject.transform.position = playerRespawnTransform.transform.position;
            gameObject.transform.rotation = playerRespawnTransform.transform.rotation;
        }
    }
}
