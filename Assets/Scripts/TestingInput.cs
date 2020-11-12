using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInput : MonoBehaviour
{
    public GameObject track1;
    Renderer r1;
    public GameObject track2;
    Renderer r2;
    public AudioClip soundFX;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        r1 = track1.transform.gameObject.GetComponent<Renderer>();
        r2 = track2.transform.gameObject.GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // OVRInput.Controller activeController = OVRInput.GetActiveController(); // trying to get the primary controller for use passing into a list of controllers


        float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (indexTrigger != 0.0f)
        {

            r1.material.color = Color.blue; //
            r2.material.color = Color.blue;
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

            StartCoroutine("WaitAndStopHaptics"); //stop hapic feedback after 0.2 seconds
        }

        float secindexTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (secindexTrigger != 0.0f)
        {

            r1.material.color = Color.cyan; //
            r2.material.color = Color.cyan; //

            //Using an audio clip to play
            audioSource.Play();

            //create haptic clip and pass to right controller
            OVRHapticsClip ovrClip = new OVRHapticsClip(soundFX);
            OVRHaptics.RightChannel.Preempt(ovrClip);

        }




    }

    IEnumerator WaitAndStopHaptics()
    {
        // suspend execution for 1 seconds
        yield return new WaitForSeconds(0.2f);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        print("Wait Stop Haptics completed.");
    }
}