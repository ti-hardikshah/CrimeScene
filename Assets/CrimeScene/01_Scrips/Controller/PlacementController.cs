using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="m_ItemPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
///


[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
	public GameObject m_ItemPrefab;
	public float m_minimumThreshold = 0.001f;
    public static event Action onPlacedObject;


    private FocusSquare m_FocusSquare;
	private Transform m_ItemTransform;
    private ARPointCloudManager pointCloudManager;

    enum PlacementState
	{
		NotPlaced,
		PlacementInProgress,
		Placed
	};

    private void Awake()
    {
       
        Application.targetFrameRate = 60;

    }

    private void Start()
    {
        m_FocusSquare = GetComponent<FocusSquare>();
        pointCloudManager = GetComponent<ARPointCloudManager>();
    }

    private PlacementState m_objectPlacementState = PlacementState.NotPlaced;

	void FixedUpdate()
	{

		if (m_FocusSquare.SquareState == FocusState.Found)
		{

			switch (m_objectPlacementState)
			{
				case PlacementState.NotPlaced:
					if (Utils.WasTouchStartDetected())
					{
                        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){

                            m_ItemPrefab.SetActive(true);
                            m_ItemTransform = m_ItemPrefab.transform;
                            m_ItemTransform.position = m_FocusSquare.placementPose.position;

                           // m_ItemTransform.LookAt(Camera.main.transform.position);
                           // m_ItemTransform.eulerAngles = new Vector3(0, m_ItemTransform.eulerAngles.y, 0);
                         
                            m_FocusSquare.isObjectPlaced = true;
                            m_FocusSquare.placementIndicator.SetActive(false);

                          //  m_ItemTransform.SetPositionAndRotation(m_FocusSquare.placementPose.position, m_FocusSquare.placementPose.rotation);

                            m_FocusSquare.PlacementFinished();
                            m_objectPlacementState = PlacementState.Placed;

                            StopPlaneTracking();
                            StopPointCloud();

                            Debug.Log("<color=green>Object Placed Once </color>" + m_ItemTransform.name);
                            onPlacedObject?.Invoke();
                        }
                    }
					break;
			}

		}


	}



	public void StopPlaneTracking() {

		m_FocusSquare.TogglePlaneDetection(false);
	}

	public void StartPlaneTracking() {

		m_FocusSquare.TogglePlaneDetection(true);
	}


    public void ResetAll() {
        m_FocusSquare.isObjectInProgress = true;
        m_FocusSquare.isObjectPlaced = false;
        m_objectPlacementState = PlacementState.NotPlaced;
        StartPlaneTracking();
    }


    public void StopPointCloud()
    {

        var points = pointCloudManager.trackables;
        foreach (var pts in points)
        {
            pts.gameObject.SetActive(false);
        }
        pointCloudManager.enabled = false;
    }

    public void StartPointCloud()
    {

        var points = pointCloudManager.trackables;
        foreach (var pts in points)
        {
            pts.gameObject.SetActive(true);
        }
        pointCloudManager.enabled = true;
    }

}


