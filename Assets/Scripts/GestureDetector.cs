using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// struct = class without function (just to hold data)
[System.Serializable]
public struct Gesture
{
    public string name; // name of the pose
    public List<Vector3> fingerDatas; // position data of the pose
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    public float threshold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures; // list inside the Gesture struct
    //public bool debugMode = true; // possible space might be used for other things 
    private List<OVRBone> fingerBones;
    private Gesture previousGesture;

    private void Start()
    {
        StartCoroutine(GetFingerBones());
        previousGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // if space is not being used already for something else, and it is pressed // removed debugMode &&  from if statement
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
            Save();
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());
        // Check if new gesture
        if(hasRecognized && !currentGesture.Equals(previousGesture))
        {
            //New gesture
            Debug.Log("New Gesture Found : " + currentGesture.name);
            previousGesture = currentGesture;
            currentGesture.onRecognized.Invoke();
        }

    }

    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            // finger position relative to the root (hands)
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
                if(distance>threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }

        return currentGesture;
    }

    IEnumerator GetFingerBones()
    {
        do
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
            yield return null;
        } while (fingerBones.Count <= 0);
    }
}
