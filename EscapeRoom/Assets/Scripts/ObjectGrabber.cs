using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private bool isGrabbing = false;
    private GameObject grabbedObject;
    private float grabDistance = 1.5f;
    private float minGrabDistance = .5f;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.green);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGrabbing)
            {
                ReleaseObject();
            }
            else
            {
                GrabObject();
            }
        }
        if (isGrabbing && grabbedObject != null)
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
                grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                Physics.IgnoreLayerCollision(7, 7);
                isGrabbing = true;
            }
        }
    }

    public void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            Debug.Log("NO");
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            Physics.IgnoreLayerCollision(7, 7, false);
            grabbedObject = null;
            isGrabbing = false;

        }
    }

    void UpdateObjectPosition()
    {
        float targetDistance = grabDistance;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, ~LayerMask.GetMask("Grabbable")))
        {
            targetDistance = Mathf.Min(hit.distance, minGrabDistance);
        }
        Vector3 targetPosition = transform.position + transform.forward * targetDistance;
        grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, targetPosition, Time.deltaTime * 10);
    }
}
