using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColour : MonoBehaviour
{
    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    public void SetGreen()
    {
        r.material.color = Color.green;

        //build an thread the loops through colour until its green from red.

    }

    public void SetRed()
    {
        r.material.color = Color.red;

    }

    public void SetBlack()
    {
        r.material.color = Color.black;

    }
}
