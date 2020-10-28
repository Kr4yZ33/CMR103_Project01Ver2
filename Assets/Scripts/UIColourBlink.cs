using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColourBlink : MonoBehaviour
{
    Renderer r;
    public float resetTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkRed());
    }

    // Update is called once per frame
    void Update()
    {
        r = GetComponent<Renderer>();
    }

    IEnumerator BlinkRed()
    {
        r.material.color = Color.red;
        yield return new WaitForSeconds(resetTime);
        r.material.color = Color.yellow;
        yield return new WaitForSeconds(resetTime);

    }
}
