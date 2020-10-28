using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject gm;

    //rotate the object in space
    public void SetRotation(float speed)
    {
        gm.transform.Rotate(speed, 0.0f, 0.0f);
    }
}
