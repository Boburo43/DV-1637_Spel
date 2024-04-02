using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private bool isGrabbing = false;
    private GameObject grabbedObject;
    
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.green);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGrabbing)
            {
                grabbedObject.gameObject.GetComponent<BoxCollider>().enabled = true;
                ReleaseObject();
            }
            else
            {
                GrabObject();
            }
        }
        if (isGrabbing)
        {
            UpdateObjectPosition();
        }
    }
    void GrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 3, out hit))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                Debug.Log("OK");
                grabbedObject = hit.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                isGrabbing = true;
            }
        }
    }

    void ReleaseObject()
    {
        if (grabbedObject != null) 
        {
            Debug.Log("NO");
            grabbedObject.GetComponent<Rigidbody>().isKinematic=false;
            grabbedObject = null;
            isGrabbing = false;

        }
    }

    void UpdateObjectPosition()
    {
        if (grabbedObject != null)
        {
            grabbedObject.gameObject.GetComponent<BoxCollider>().enabled = false;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z) + transform.forward;
            grabbedObject.GetComponent<Rigidbody>().MovePosition(newPosition);
        }
    }
}
