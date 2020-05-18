using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCamController : MonoBehaviour
{
    [SerializeField]
        Camera ARCamera;
    [SerializeField]
        Camera VirtualCamera;
    [SerializeField]
        GameObject Player;
    [SerializeField]
        GameObject JoystickController;

    bool isObjectPlaced = false;

    public LayerMask Nothing;
    public LayerMask Everything;


    private void OnEnable()
    {
        PlacementController.onPlacedObject += ActivateVirtualCamera;
    }

    private void OnDisable()
    {
       PlacementController.onPlacedObject -= ActivateVirtualCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (isObjectPlaced) {
            Player.transform.rotation = ARCamera.transform.rotation;
            VirtualCamera.transform.localPosition = ARCamera.transform.position;
        }
    }


    public void ActivateVirtualCamera() {

        ARCamera.depth = 0;
        ARCamera.cullingMask = Nothing;
        //ARCamera.enabled = false;
        VirtualCamera.depth = 1;
        VirtualCamera.cullingMask = Everything;

        // VirtualCamera.enabled = true;

        Player.transform.position = ARCamera.transform.position;
        Player.transform.eulerAngles = new Vector3(0, 90f, 0);

        // ARCamera.cullingMask = Nothing;
        // VirtualCamera.cullingMask = Everything;

        if (PlayerPrefs.GetInt("IsLazyMode", 1) == 1)
        {
            JoystickController.SetActive(false);
        }
        else
        {
            JoystickController.SetActive(true);
        }

        isObjectPlaced = true;
    }




}
