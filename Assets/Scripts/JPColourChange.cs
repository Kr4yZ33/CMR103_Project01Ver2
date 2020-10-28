using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPColourChange : MonoBehaviour
{
    Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    public void SetRed()
    {
        r.material.color = Color.red;
    }

    public void SetGreen()
    {
        r.material.color = Color.green;
    }

    public void SetRandom()
    {
        int rand = Random.Range(1, 6);
        r.material.color = randomColor(rand);
    }

    //use this method to select a random color...need to pass it a random value **********ADAM**********
    public Color randomColor(int randomNumnber)
    {
        switch (randomNumnber)
        {
            case 1: return Color.blue;
            case 2: return Color.black;
            case 3: return Color.yellow;
            case 4: return Color.magenta;
            case 5: return Color.cyan;
            case 6: return Color.green;
        }
        return Color.red;
    }
}
