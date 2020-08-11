using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacingWithIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject placementIndicator;

    [SerializeField]
    private Camera arCamera;

    private ARSessionOrigin arOrigin;

    private ARRaycastManager arRaycastManager;

    private Pose placementPose; //describe the position & rotation of a 3D point

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool placementPoseIsValid = false;


    // Start is called before the first frame update
    void Awake()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }


    private void UpdatePlacementPose()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else
        {
            placementIndicator.SetActive(false);
        }
        
    }
}
