using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AutoSlotPlacement : MonoBehaviour
{
    public GameObject slotPrefab;
    private ARSessionOrigin _arSessionOrigin;
    private ARRaycastManager _arRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_arRaycastManager.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f)), hits, TrackableType.PlaneWithinPolygon))
        { 
            Pose hitPose = hits[0].pose;
            slotPrefab.transform.position = hitPose.position;
        }
    }
}
