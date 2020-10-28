using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsUp : MonoBehaviour
{
    public float tolerance = 0.9f; // Used to set the value of dot product
    public bool upsideDown;

    // Update is called once per frame
    void Update()
    {
        if (IsUpsideDown()) // if the function IsUpsideDown is called
        {
            //Debug.Log("Is Upside Down"); // debug out Is Upside Down when t his function is called
            upsideDown = true;
        }
        else
        {
            //Debug.Log("Is Right Side Up"); // otherwise debug out Is right side up
            upsideDown = false;
        }

        float valueOfDotProduct = Vector3.Dot(transform.up, Vector3.up); // sets the value of the dot product
        //Debug.Log("The Dot Product is " + valueOfDotProduct); // debug to log The Dot Product is "whatever the value is"
    }

    /// <summary>
    /// function to work out if the object is upside down
    /// </summary>
    /// <returns></returns>
    public bool IsUpsideDown()
    {
        return (Vector3.Dot(transform.up, Vector3.up) < -tolerance); // return coordinate details of up
    }
}
