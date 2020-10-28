using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColourBlink : MonoBehaviour
{
    Renderer r;
    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        StartCoroutine(BlinkRed());
    }

    IEnumerator BlinkRed()
    {
        r.material.color = Color.red;
        yield return new WaitForSeconds(1);
        r.material.color = Color.yellow;
        yield return new WaitForSeconds(1);

    }
}
