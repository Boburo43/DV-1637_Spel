using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject plate;
    [SerializeField] bool isOpened = false;
    private Vector3 doorClosedPosition;
    private Vector3 doorOpenPosition;
    private Vector3 plateOriginalPosition;
    private float transitionSpeed = 3f;

    void Start()
    {
        doorClosedPosition = door.transform.position;
        doorOpenPosition = doorClosedPosition + new Vector3(-4f, 0, 0);
        plateOriginalPosition = plate.transform.position;
    }

    void Update()
    {
        if (isOpened)   
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorOpenPosition, Time.deltaTime * transitionSpeed);
            plate.transform.position = new Vector3(plateOriginalPosition.x, plateOriginalPosition.y - 0.02f, plateOriginalPosition.z);
        }
        else
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorClosedPosition, Time.deltaTime * transitionSpeed);
            plate.transform.position = plateOriginalPosition;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        isOpened = true;
    }

    private void OnTriggerExit(Collider col)
    {
        isOpened = false;
    }
}
