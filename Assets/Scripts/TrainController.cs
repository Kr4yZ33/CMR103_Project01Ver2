using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip trainSteam;
    public AudioClip trainHorn;

    public bool startMoving;
    //public bool trainHeld;
    //public bool edgeTransition;
    public bool trainingRight;
    public bool trainingLeft;

    public GameObject audioSourceObject;
    public Transform startingPos;
    public Vector3 targetPosition; // reference to our target position
    public Transform currentTarget;
    public Transform previousTarget;

    public float trainSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = startingPos.position;
        transform.position = targetPosition;

    }

    void Update()
    {

        //if (trainHeld == true)
        //{
            //currentTarget = previousTarget;
            //currentTarget = null;
            //trainSpeed = 0f;
        //}
        if (startMoving == true)
        {
            targetPosition = currentTarget.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * trainSpeed);
        }
    }

    private void FixedUpdate()
    {
        if(startMoving == true)
        {
            return;
        }
        
        if(trainingRight == true && trainingLeft == true)
        {
            trainSpeed = 0.1f;
            audioSourceObject.SetActive(true);
            startMoving = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Horn"))
        {
            PlayTrainHorn();
        }

        //if (other.CompareTag("Player"))
        //{
            //trainHeld = true;
        //}

        //if (other.CompareTag("TrackEdge"))
        //{
            //edgeTransition = true;
        //}
    }

    //void OnTriggerExit(Collider other)
    //{
        //if (other.CompareTag("Player"))
        //{
            //trainHeld = false;
            //currentTarget = startingPos;
        //}

        //if (other.CompareTag("TrackEdge"))
        //{
            //edgeTransition = false;
        //}
    //}

    void PlayTrainHorn()
    {
        audioSource.PlayOneShot(trainSteam);
        audioSource.PlayOneShot(trainHorn);
    }
}
