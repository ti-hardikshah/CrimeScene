using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class StairesTrigger : MonoBehaviour
{
    public enum Type { Enter,Exit };

    public Type myType;


    public Transform EnterPosition;
    public Transform ExitPosition;

    Vector3 wPos;


    public Canvas can;


    public GameObject camObject;


    public GameObject portalDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     void OnTriggerEnter(Collider other)
    {
        Debug.Log("Controller"+ PlayerPrefs.GetInt("IsLazyMode")+" "+other.gameObject.name);
        if (PlayerPrefs.GetInt("IsLazyMode") == 1 && other.gameObject.tag.Equals("MainCamera"))
        {

            switch (myType) {


                case Type.Enter:
                     Debug.Log("<color=green>Enter</color>");
                   // wPos = transform.TransformPoint(ExitPosition.position);

                    wPos = ExitPosition.position;
                    break;

                case Type.Exit:
                     Debug.Log("<color=blue>Exit</color>");
                  //  wPos = transform.TransformPoint(EnterPosition.position);
                   wPos = EnterPosition.position;
                    break;

            }


            if(camObject==null)
            camObject = other.gameObject;

            // Debug.Log("Position update"+wPos);

            camObject.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.RotationOnly;

            can.gameObject.SetActive(true);

           // Debug.Log(other.gameObject.transform.position);
           // other.gameObject.transform.position = wPos;
           //Debug.Log(other.gameObject.transform.position);

            //other.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        }

    }
    */


    private void OnTriggerEnter(Collider other)
    {
        switch (myType)
        {

            case Type.Enter:
                if (!portalDoor.activeSelf)
                {
                    portalDoor.SetActive(true);
                }
                break;

            case Type.Exit:

                if (portalDoor.activeSelf) {

                    portalDoor.SetActive(false);
                }

                break;

        }
    }


    public void Jump() {


        StartCoroutine(MoveToTarget());
    }


    public void Cancel() {


        camObject.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        can.gameObject.SetActive(false);
    }

    IEnumerator MoveToTarget()
    {

        Debug.Log("Before :"+camObject.GetComponent<TrackedPoseDriver>().originPose.position);

        Debug.Log(camObject.gameObject.transform.position);
        camObject.gameObject.transform.position = wPos;
        Debug.Log(camObject.gameObject.transform.position);

        yield return new WaitForSeconds(2f);

        camObject.GetComponent<TrackedPoseDriver>().trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        can.gameObject.SetActive(false);

        Debug.Log("After :" + camObject.GetComponent<TrackedPoseDriver>().originPose.position);
    }
}
