using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class PlacementController : MonoBehaviour
{
    public GameObject placedPrefab;
    private GameObject placedObject;

    private ARRaycastManager _arRaycastManager;

    private Vector2 touchPosition;

    //private const float prefabRotation = 180.0f;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetTouchPosition(out Vector2 touchPosition))
        {
            return;

            if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                if (placedObject == null)
                {
                    placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    placedObject.transform.position = hitPose.position;
                }
            }
        }

        /*
        Touch touch = Input.GetTouch(0);

        touchPosition = touch.position;

        if (touch.tapCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hitObject;

            if (Physics.Raycast(ray, out hitObject))
            {
                if (hitObject.transform.name == "Sphere")
                {
                    onTouchHold = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;
            }


            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
        }

        if (onTouchHold)
        {
            if (_arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
            {
                Pose hitPose = hits[0].pose;

                if (placedObject != null)
                {
                    placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                }
                else {
                    placedObject.transform.position = hitPose.position;
                    placedObject.transform.rotation = hitPose.rotation;
                }

                Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
        }
        */
    }
}
