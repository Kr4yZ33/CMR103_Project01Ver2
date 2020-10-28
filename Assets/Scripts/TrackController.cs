using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public GameObject piece1;
    public GameObject piece2;
    public bool trackUpsideDown;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTrackAlignment();
    }

    void CheckTrackAlignment()
    {
        if (Vector3.Dot(piece1.transform.up, piece2.transform.up) > 0.7f)
        {
            Debug.Log("Facing same direction UP");
            // They are roughly facing the same upwards
            trackUpsideDown = false;
        }
    }
    
}
