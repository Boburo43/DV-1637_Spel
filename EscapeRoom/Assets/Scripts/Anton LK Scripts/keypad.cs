using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypad : MonoBehaviour
{
    public ObjectGrabber oG;

    [SerializeField] GameObject door;
    [SerializeField] GameObject key;
    [SerializeField] Transform keyHolder;

    private Vector3 doorClosedPosition;
    private Vector3 doorOpenPosition;
    private float transitionSpeed = 3f;

    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        doorClosedPosition = door.transform.position;
        doorOpenPosition = doorClosedPosition + new Vector3(-5f, 0, 0);
        open = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(open == true)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, doorOpenPosition, Time.deltaTime * transitionSpeed);
            key.transform.position = keyHolder.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(oG.grabbedObject == key)
        {
            open = true;

        }
    }
}
