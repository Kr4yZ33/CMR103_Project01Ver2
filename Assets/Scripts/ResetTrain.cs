using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrain : MonoBehaviour
{

    public Transform startPos;
    public GameObject train;

    public void ResetTrainPrefab()
    {
        train.transform.position = startPos.transform.position;
        train.transform.rotation = startPos.transform.rotation;
        train.SetActive(false);
        train.SetActive(true);
    }
}
