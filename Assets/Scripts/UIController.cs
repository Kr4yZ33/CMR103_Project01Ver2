﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
   
    public bool firstTrackGrab;
    public bool firstTrackPlace;
    public bool secondTrackGrab;
    public bool secondTrackPlace;

    public bool excessiveTimeBetweenTrackPickup;
    public bool excessiveTimeToPlaceTrack1;
    public bool excessiveTimeToPlaceTrack2;

    public GameObject firstTrackPiece;
    public GameObject secondTrackPiece;
    public GameObject trackPlacementSpot1;
    public GameObject trackPlacementSpot2;
    public GameObject xrRigUi;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitialUI());

        if (firstTrackGrab == true)
        {
            firstTrackGrab = true;
            firstTrackPiece.SetActive(false);
            StartCoroutine(SecondTrackPieceHelper());
        }

        if(secondTrackGrab == true)
        {
            secondTrackPiece.SetActive(false);
            excessiveTimeBetweenTrackPickup = false;
        }

        if(firstTrackGrab == true)
        {
            StartCoroutine(ExcessiveTimeToPlaceTrack1());
        }

        if(secondTrackGrab == true)
        {
            StartCoroutine(ExcessiveTimeToPlaceTrack2());
        }
        
        if(excessiveTimeToPlaceTrack1 == false)
        {
            trackPlacementSpot1.SetActive(false);
        }

        if (excessiveTimeToPlaceTrack2 == false)
        {
            trackPlacementSpot2.SetActive(false);
        }


    }

    private void Update()
    {
        if (excessiveTimeBetweenTrackPickup == false)
        {
            secondTrackPiece.SetActive(false);
        }
    }

    public IEnumerator InitialUI()
    {
        yield return new WaitForSeconds(10);
        xrRigUi.SetActive(false);
    }

    public IEnumerator FirstTrackPiece()
    {
        yield return new WaitForSeconds(2);
        firstTrackPiece.SetActive(false);
    }

    public IEnumerator SecondTrackPieceHelper()
    {
        yield return new WaitForSeconds(10);
        if (excessiveTimeBetweenTrackPickup == false)
        {
            yield break;
        }
        else
        {
            secondTrackPiece.SetActive(true);
        }
    }

    public IEnumerator ExcessiveTimeBetweenTrackPickup()
    {
        yield return new WaitForSeconds(10);
        if(secondTrackGrab == true)
        {
            yield break;
        }
        else
        {
            excessiveTimeBetweenTrackPickup = true;
        }
    }

    public IEnumerator ExcessiveTimeToPlaceTrack1()
    {
        yield return new WaitForSeconds(10);
        if (firstTrackPlace == true)
        {
            yield break;
        }
        else excessiveTimeToPlaceTrack1 = true;
        trackPlacementSpot1.SetActive(true);
    }

    public IEnumerator ExcessiveTimeToPlaceTrack2()
    {
        yield return new WaitForSeconds(10);
        if (secondTrackPlace == true)
        {
            yield break;
        }
        else excessiveTimeToPlaceTrack2 = true;
        trackPlacementSpot2.SetActive(true);
    }
}
