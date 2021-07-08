using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SnapPlacement : MonoBehaviour
{
    public bool isSnapped;

    public GameObject slot;

    public Material collided;
    public Material notCollided;
    public Material collidedBack;

    public Quaternion originalRot;
    public Vector3 originalPos;

    public Vector3 slotPos;
    //public Vector3 placedObjectPos;

    void Start()
    {
        slot = GameObject.Find("Slot");

        originalRot = gameObject.transform.rotation;
        originalPos = gameObject.transform.position;

        slotPos = slot.transform.position;
        //snapObject.GetComponent<MeshRenderer>().material = notCollided;

        isSnapped = false;
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Slot")
        {
            Debug.Log("Object made contact with slot");
            //slot.GetComponent<MeshRenderer>().material = collided;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Slot")
        {
            //slot.GetComponent<MeshRenderer>().material = collided;

            if (Input.touchCount > 0)
            {
                if (isSnapped == false)
                {
                    //gameObject.transform.SetParent(slot.transform, true);
                    transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);
                    transform.rotation = slot.GetComponent<Transform>().rotation;

                    Debug.Log("Positions and Rotations of Cube are same as Snap Cube");
                    isSnapped = true;
                }
                else
                {
                    //snapBackCube.SetActive(true);
                    Debug.Log("Snap Back mechanism now available");
                    //gameObject.transform.SetParent(slot.transform, false);
                    GetComponent<Transform>().position = originalPos;
                    GetComponent<Transform>().rotation = originalRot;

                    isSnapped = false;
                }
            }

            /*

             && Input.touches[0].phase == TouchPhase.Began
             
             */
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Slot")
        {
            Debug.Log("Cube NOT LONGER in contact with Snap Cube");
            //slot.GetComponent<MeshRenderer>().material = notCollided;
        }
    }
}
